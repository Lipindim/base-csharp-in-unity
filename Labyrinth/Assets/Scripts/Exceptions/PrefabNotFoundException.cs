using System;


namespace Labyrinth
{
    public class PrefabNotFoundException : Exception
    {
        public PrefabNotFoundException(string name) : base($"Не найден префаб для объекта '{name}'.")
        {
        }
    }
}
