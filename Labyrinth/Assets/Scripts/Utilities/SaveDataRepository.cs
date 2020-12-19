using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Labyrinth
{
    public class SaveDataRepository
    {
        private readonly IData<SavedData> _data;
        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;
        public SaveDataRepository()
        {
            _data = new JsonData<SavedData>();
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(Vector3 playerPosition, IEnumerable<GameObject> interactiveObjects)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            { 
                Directory.CreateDirectory(_path);
            }
            List<InteractiveObjectModel> interactiveObectModels = new List<InteractiveObjectModel>();
            foreach (var item in interactiveObjects)
            {
                if (item != null)
                {
                    InteractiveObject interactiveObject = item.GetComponent<InteractiveObject>();
                    InteractiveObjectEnum type;
                    if (interactiveObject is SpeedBost)
                        type = InteractiveObjectEnum.SpeedBost;
                    else if (interactiveObject is RequiredKey)
                        type = InteractiveObjectEnum.RequiredKey;
                    else if (interactiveObject is InvulnerabilityBost)
                        type = InteractiveObjectEnum.InvulnerabilityBost;
                    else if (interactiveObject is SlowTrap)
                        type = InteractiveObjectEnum.SlowTrap;
                    else if (interactiveObject is DeathTrap)
                        type = InteractiveObjectEnum.DeathTrap;
                    else
                        throw new System.Exception($"Неизвестный интерактивный объект: {interactiveObject.GetType()}");

                    interactiveObectModels.Add(new InteractiveObjectModel()
                    {
                        Position = item.transform.position,
                        Type = type
                    });
                }
            }

            var savePlayer = new SavedData
            {
                Position = playerPosition,
                InteractiveObjects = interactiveObectModels.ToArray()
            };
            _data.Save(savePlayer, Path.Combine(_path, _fileName));
        }
        public bool Load(out SavedData savedData)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                savedData = null;
                return false;
            }
            savedData = _data.Load(file);
            return true;
        }
    }
}
