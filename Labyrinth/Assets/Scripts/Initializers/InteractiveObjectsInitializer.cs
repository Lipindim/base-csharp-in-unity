using System;
using System.Collections.Generic;
using UnityEngine;


namespace Labyrinth
{
    public class InteractiveObjectsInitializer
    {
        public static IEnumerable<GameObject> Initialize(InteractiveObjectSettings interactiveObjectSettings)
        {
            List<GameObject> gameObjects = new List<GameObject>();
            foreach (var item in interactiveObjectSettings.Objects)
            {
                switch (item.Type)
                {
                    case InteractiveObjectEnum.SlowTrap:
                        {
                            var gameObject = GameObject.Instantiate(interactiveObjectSettings.SlowTrapPrefab, item.Position, Quaternion.identity);
                            gameObjects.Add(gameObject);
                            break;
                        }
                    case InteractiveObjectEnum.DeathTrap:
                        {
                            var gameObject = GameObject.Instantiate(interactiveObjectSettings.DeathTrap, item.Position, Quaternion.identity);
                            gameObjects.Add(gameObject);
                            break;
                        }
                    case InteractiveObjectEnum.RequiredKey:
                        {
                            var gameObject = GameObject.Instantiate(interactiveObjectSettings.RequiredKeyPrefab, item.Position, Quaternion.identity);
                            gameObjects.Add(gameObject);
                            break;
                        }
                    case InteractiveObjectEnum.SpeedBost:
                        {
                            var gameObject = GameObject.Instantiate(interactiveObjectSettings.SpeedBoostPrefab, item.Position, Quaternion.identity);
                            gameObjects.Add(gameObject);
                            break;
                        }
                    case InteractiveObjectEnum.InvulnerabilityBost:
                        {
                            var gameObject = GameObject.Instantiate(interactiveObjectSettings.InvulnerabilityBostPrefab, item.Position, Quaternion.identity);
                            gameObjects.Add(gameObject);
                            break;
                        }
                    default:
                        throw new Exception($"Неподдерживаемый тип интерактивного объекта: {item.Type}");
                }
            }

            return gameObjects;
        }
    }
}
