using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Labyrinth
{
    public class KeyboardController : IUpdatable
    {

        #region Fields

        private GameObject _player;
        private IEnumerable<GameObject> _interactiveObjects;
        private SaveDataRepository _saveDataRepository;

        #endregion


        #region ClassLifeCycles

        public KeyboardController(GameObject player, IEnumerable<GameObject> interactiveObjects)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));
            if (interactiveObjects == null)
                throw new ArgumentNullException(nameof(interactiveObjects));

            _player = player;
            _interactiveObjects = interactiveObjects;
            _saveDataRepository = new SaveDataRepository();
        }

        #endregion


        #region IUpdatable

        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();

            if (Input.GetKeyDown(KeyCode.F4))
                _saveDataRepository.Save(_player.transform.position, _interactiveObjects);

            if (Input.GetKeyDown(KeyCode.F6))
            {
                GameSettings.LoadMode = true;
                SceneManager.LoadScene(0);
            }
        }

        #endregion

    }
}
