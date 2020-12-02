using UnityEngine;

namespace Labyrinth
{
    public class KeyCollectedController : MonoBehaviour
    {
        public bool IsKeyCollected
        {
            get
            {
                return _keysCount == _keysCollected;
            }
        }

        private int _keysCount;
        private int _keysCollected;


        private void Start()
        {
            var requiredKeys = FindObjectsOfType<RequiredKey>();
            foreach (var requiredKey in requiredKeys)
                requiredKey.OnInteraction += RequiredKey_OnInteraction;

            _keysCount = requiredKeys.Length;
        }

        private void RequiredKey_OnInteraction(InteractiveObject obj)
        {
            _keysCollected++;

            if (_keysCollected == _keysCount)
                Debug.Log("Все ключи собраны.");
            else
                Debug.Log("Ключ собран.");
        }
    }
}
