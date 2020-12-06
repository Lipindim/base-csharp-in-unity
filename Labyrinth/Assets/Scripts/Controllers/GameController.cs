using System.Collections.Generic;
using UnityEngine;


namespace Labyrinth
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private CameraSettings _cameraSettings;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private AudioData _audioData;
        [SerializeField] private UiData _uiData;
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private GameObject _victoryImage;

        private List<IUpdate> _updatebles = new List<IUpdate>();
        private List<object> _notUpdatebles = new List<object>();
        private UiController _uiController;

        private void Start()
        {
            Debug.Log("Стартую");
            var player = PlayerInitializer.Initialize(_playerData);
            var playerRigidbody = player.GetComponent<Rigidbody>();
            var audioSource = player.GetComponent<AudioSource>();
            var interactiveObjects = FindObjectsOfType<InteractiveObject>();
            var playerModel = new PlayerModel(_playerData);
            
            _updatebles.Add(new MoveController(interactiveObjects, playerModel , playerRigidbody));
            _updatebles.Add(new CameraController(_cameraSettings, player));
            _updatebles.Add(new KeyboardController());
            _updatebles.Add(new InvulnerabilityBostController(interactiveObjects, playerModel));

            _uiController = new UiController(_restartButton, _victoryImage);
            _notUpdatebles.Add(_uiController);
            _notUpdatebles.Add(new DeathController(interactiveObjects, _uiController.ShowRestart, playerModel));
            _notUpdatebles.Add(new AudioPlayer(_audioData, interactiveObjects, playerModel, audioSource));
            _notUpdatebles.Add(new KeyCollectedController(interactiveObjects, _uiController.Victory));
        }


        private void Update()
        {
            foreach (var updateble in _updatebles)
            {
                updateble.Update(Time.deltaTime);
            }

        }

        public void Restart()
        {
            _uiController.RestartGame();
        }
    }
}
