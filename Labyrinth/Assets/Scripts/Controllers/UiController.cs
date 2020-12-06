using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Labyrinth
{
    public class UiController
    {
        private GameObject _victoryImage;
        private GameObject _restartButton;

        public UiController(GameObject restartButton, GameObject victoryImage)
        {
            _victoryImage = victoryImage;
            _restartButton = restartButton;
            var button = restartButton.GetComponent<Button>();
            _restartButton.SetActive(false);
        }

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
    }
}
