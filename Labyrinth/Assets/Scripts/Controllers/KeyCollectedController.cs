using System;
using System.Collections.Generic;
using UnityEngine;


namespace Labyrinth
{
    public class KeyCollectedController
    {

        #region Fields

        private Action _onKeyCollected;

        private int _keysCount;
        private int _keysCollected;

        #endregion


        #region Properties

        public bool IsKeyCollected
        {
            get
            {
                return _keysCount == _keysCollected;
            }
        }

        #endregion


        #region ClassLifeCycles

        public KeyCollectedController(IEnumerable<InteractiveObject> interactiveObjects, Action onKeyCollected)
        {
            foreach (var interactiveObject in interactiveObjects)
            {
                if (interactiveObject is RequiredKey requiredKey)
                {
                    requiredKey.OnInteraction += RequiredKey_OnInteraction;
                    _keysCount++;
                }
            }

            _onKeyCollected = onKeyCollected;
        }

        #endregion


        #region Methods

        private void RequiredKey_OnInteraction(InteractiveObject obj)
        {
            _keysCollected++;

            if (_keysCollected == _keysCount)
            {
                _onKeyCollected?.Invoke();
            }
            else
            {
                Debug.Log("Ключ собран.");
            }
        }

        #endregion

    }
}
