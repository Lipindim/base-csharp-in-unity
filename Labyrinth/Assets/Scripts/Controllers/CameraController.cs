using UnityEngine;


namespace Labyrinth
{
    public sealed class CameraController : IUpdatable
    {

        #region Fields

        private CameraSettings _cameraSettings;
        private GameObject _player;
        private Camera _camera;

        #endregion


        #region ClassLifeCycles
        
        public CameraController(CameraSettings cameraSettings, GameObject player, Camera camera)
        {
            _player = player;
            _camera = camera;
            _cameraSettings = cameraSettings;
        }

        #endregion


        #region IUpdatable

        public void Update(float deltaTime)
        {
            _camera.transform.position = _player.transform.position + _cameraSettings.CameraOffset;
        }

        #endregion

    }
}
