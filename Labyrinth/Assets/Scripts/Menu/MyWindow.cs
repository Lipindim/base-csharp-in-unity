using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Labyrinth.Editor
{
    public class MyWindow : EditorWindow
    {
        public static InteractiveObjectSettings InteractiveObjectSettings;
        private static GameObject _root;

        private void OnGUI()
        {
            GUILayout.Label("Интерактивные объекты", EditorStyles.boldLabel);
            InteractiveObjectSettings =
               EditorGUILayout.ObjectField("Файл настроек",
                     InteractiveObjectSettings, typeof(InteractiveObjectSettings), true)
                  as InteractiveObjectSettings;

            var button = GUILayout.Button("Создать объекты");
            if (button)
            {
                if (InteractiveObjectSettings)
                {
                    _root = new GameObject("Root");
                    foreach (var interactiveObject in InteractiveObjectSettings.Objects)
                    {
                        GameObject prefab;
                        switch (interactiveObject.Type)
                        {
                            case InteractiveObjectEnum.SlowTrap:
                                prefab = InteractiveObjectSettings.SlowTrapPrefab;
                                break;
                            case InteractiveObjectEnum.DeathTrap:
                                prefab = InteractiveObjectSettings.DeathTrapPrefab;
                                break;
                            case InteractiveObjectEnum.RequiredKey:
                                prefab = InteractiveObjectSettings.RequiredKeyPrefab;
                                break;
                            case InteractiveObjectEnum.SpeedBost:
                                prefab = InteractiveObjectSettings.SpeedBoostPrefab;
                                break;
                            case InteractiveObjectEnum.InvulnerabilityBost:
                                prefab = InteractiveObjectSettings.InvulnerabilityBostPrefab;
                                break;
                            default:
                                throw new System.Exception($"Unknown object type: {interactiveObject.Type}");
                        }
                        GameObject temp = Instantiate(prefab, interactiveObject.Position,
                           Quaternion.identity);
                        temp.transform.parent = _root.transform;
                    }
                }
            }

            var saveButton = GUILayout.Button("Сохранить настройки");
            if (saveButton)
            {
                if (_root)
                {
                    if (InteractiveObjectSettings)
                    {
                        var interactiveObjects = GameObject.FindObjectsOfType<InteractiveObject>();
                        List<InteractiveObjectModel> newObjects = new List<InteractiveObjectModel>();
                        foreach (var item in interactiveObjects)
                        {
                            newObjects.Add(new InteractiveObjectModel()
                            {
                                Position = item.gameObject.transform.position,
                                Type = item.Type
                            });
                        }
                        InteractiveObjectSettings.Objects = newObjects.ToArray();
                    }
                }
            }

            var deleteButton = GUILayout.Button("Удалить объекты");
            if (deleteButton)
            {
                if (_root)
                    DestroyImmediate(_root);
            }
        }

    }
}
