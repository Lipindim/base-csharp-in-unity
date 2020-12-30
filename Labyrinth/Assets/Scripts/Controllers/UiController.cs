using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Labyrinth
{
    public class UiController
    {

        #region Fields

        private GameObject _victoryImage;
        private GameObject _restartButton;

        #endregion


        #region ClassLifeCycles

        public UiController(GameObject restartButton, GameObject victoryImage)
        {
            _victoryImage = victoryImage;
            _restartButton = restartButton;
            var button = restartButton.GetComponent<Button>();
            _restartButton.SetActive(false);
        }

        #endregion


        #region Methods

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
            _restartButton.SetActive(false);
        }

        public void ShowRestart()
        {
            Time.timeScale = 0.0f;
            _restartButton.SetActive(true);
        }

        public void Victory()
        {
            _victoryImage.SetActive(true);
        }

        #endregion

    }
}
