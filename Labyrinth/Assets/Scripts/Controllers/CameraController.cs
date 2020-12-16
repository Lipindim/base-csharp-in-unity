using UnityEngine;


namespace Labyrinth
{

    public sealed class CameraController : IUpdate
    {
        private CameraSettings _cameraSettings;
        private GameObject _player;
        private Camera _camera;


        public CameraController(CameraSettings cameraSettings, GameObject player, Camera camera)
        {
            _player = player;
            _camera = camera;
            _cameraSettings = cameraSettings;
        }

        public void Update(float deltaTime)
        {
            _camera.transform.position = _player.transform.position + _cameraSettings.CameraOffset;
        }
    }
}
