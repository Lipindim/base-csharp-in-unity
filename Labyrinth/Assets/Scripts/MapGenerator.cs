using System.Collections.Generic;
using UnityEngine;


namespace Labyrinth
{

    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _singleWall;

        [SerializeField] private int _rows = 30;
        [SerializeField] private int _columns = 30;
        [SerializeField] private float _positionOffsetByY = 0.5f;

        private static System.Random _rand = new System.Random();
        private GenCell[,] map;

        private void Start()
        {
            map = new GenCell[_rows, _columns];

            ClearMap(ref map);
            RemoveWall(ref map);
            BuildMap(map);
        }

        private void RemoveWall(ref GenCell[,] M)
        {
            GenCell current = M[1, 1];
            current.Visited = true;

            Stack<GenCell> stack = new Stack<GenCell>();

            do
            {
                List<GenCell> cells = new List<GenCell>();

                int row = current.Row;
                int col = current.Col;

                if (row - 1 > 0 && !M[row - 2, col].Visited) cells.Add(M[row - 2, col]);
                if (col - 1 > 0 && !M[row, col - 2].Visited) cells.Add(M[row, col - 2]);

                if (row < _rows - 3 && !M[row + 2, col].Visited) cells.Add(M[row + 2, col]);
                if (col < _columns - 3 && !M[row, col + 2].Visited) cells.Add(M[row, col + 2]);

                if (cells.Count > 0)
                {
                    GenCell selected = cells[_rand.Next(cells.Count)];
                    RamoveCurrentWall(ref M, current, selected);

                    selected.Visited = true;
                    M[selected.Row, selected.Col].Visited = true;
                    stack.Push(selected);
                    current = selected;
                }
                else
                {
                    current = stack.Pop();
                }

            } while (stack.Count > 0);
        }

        private void RamoveCurrentWall(ref GenCell[,] M, GenCell current, GenCell selected)
        {
            if (current.Row == selected.Row)
            {
                if (current.Col > selected.Col) { M[current.Row, current.Col - 1].Value = 0; }
                else { M[current.Row, selected.Col - 1].Value = 0; }
            }
            else
            {
                if (current.Row > selected.Row) { M[current.Row - 1, current.Col].Value = 0; }
                else { M[selected.Row - 1, selected.Col].Value = 0; }
            }
        }

        private void ClearMap(ref GenCell[,] M)
        {
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    if ((i % 2 != 0 && j % 2 != 0) && (i < _rows - 1 && j < _columns - 1))
                    {
                        M[i, j].Value = 0;
                    }
                    else
                    {
                        M[i, j].Value = -1;
                    }
                    M[i, j].Row = i;
                    M[i, j].Col = j;
                    M[i, j].Visited = false;
                }
            }
        }

        private void BuildMap(GenCell[,] M)
        {
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    switch (M[i, j].Value)
                    {
                        case 0:
                            break;
                        default:
                            //Построить стену
                            var position = new Vector3(i, _positionOffsetByY, j);
                            var wall = Instantiate(_singleWall, position, Quaternion.identity);
                            wall.transform.parent = this.transform;
                            break;
                    }
                }
            }
        }
    }
}
