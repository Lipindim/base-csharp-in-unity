using System;
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
        [SerializeField] private CameraSettings _miniMapCameraSettings;
        [SerializeField] private Camera _miniMapCamera;
        [SerializeField] private GameObject _mainCanvas;
        [SerializeField] private MiniMapSettings _minimapSettings;
        [SerializeField] private RadarSettings _radarSettings;
        [SerializeField] private InteractiveObjectSettings _interactiveObjectSettings;

        private List<IUpdate> _updatebles = new List<IUpdate>();
        private List<object> _notUpdatebles = new List<object>();
        private UiController _uiController;

        private void Start()
        {
            Load();
            var interactiveObjects = InteractiveObjectsInitializer.Initialize(_interactiveObjectSettings);
            var player = PlayerInitializer.Initialize(_playerData);
            var playerRigidbody = player.GetComponent<Rigidbody>();
            var audioSource = player.GetComponent<AudioSource>();
            var interactives = FindObjectsOfType<InteractiveObject>();
            var radarObjects = FindObjectsOfType<RadarObject>();
            var playerModel = new PlayerModel(_playerData);
            var minimap = MinimapInitializer.Initialize(_minimapSettings, _mainCanvas);
            
            _updatebles.Add(new MoveController(interactives, playerModel , playerRigidbody));
            _updatebles.Add(new CameraController(_cameraSettings, player, Camera.main));
            _updatebles.Add(new CameraController(_miniMapCameraSettings, player, _miniMapCamera));
            _updatebles.Add(new KeyboardController(player, interactiveObjects));
            _updatebles.Add(new InvulnerabilityBostController(interactives, playerModel));
            _updatebles.Add(new RadarController(_radarSettings, radarObjects, minimap, player));

            _uiController = new UiController(_restartButton, _victoryImage);
            _notUpdatebles.Add(_uiController);
            _notUpdatebles.Add(new DeathController(interactives, _uiController.ShowRestart, playerModel));
            _notUpdatebles.Add(new AudioPlayer(_audioData, interactives, playerModel, audioSource));
            _notUpdatebles.Add(new KeyCollectedController(interactives, _uiController.Victory));
        }

        private void Load()
        {
            if (GameSettings.LoadMode)
            {
                SaveDataRepository saveDataRepository = new SaveDataRepository();
                if (saveDataRepository.Load(out SavedData savedData));
                {
                    PlayerData playerData = new PlayerData()
                    {
                        Prefab = _playerData.Prefab,
                        Speed = _playerData.Speed,
                        StartPosition = savedData.Position
                    };
                    _playerData = playerData;
                    InteractiveObjectSettings interactiveObjectSettings = new InteractiveObjectSettings()
                    {
                        Objects = savedData.InteractiveObjects,
                        DeathTrap = _interactiveObjectSettings.DeathTrap,
                        InvulnerabilityBostPrefab = _interactiveObjectSettings.InvulnerabilityBostPrefab,
                        RequiredKeyPrefab = _interactiveObjectSettings.RequiredKeyPrefab,
                        SlowTrapPrefab = _interactiveObjectSettings.SlowTrapPrefab,
                        SpeedBoostPrefab = _interactiveObjectSettings.SpeedBoostPrefab
                    };
                    _interactiveObjectSettings = interactiveObjectSettings;
                }
            }
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
