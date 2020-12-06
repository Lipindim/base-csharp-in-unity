using System.Collections.Generic;
using UnityEngine;


namespace Labyrinth
{
    public class MoveController : IUpdate
    {

        private PlayerModel _player;
        private Rigidbody _playerRigidbody;

        private float _effectDuration;

        public MoveController(IEnumerable<InteractiveObject> interactiveObjects, PlayerModel player, Rigidbody playerRigidbody)
        {
            _player = player;
            _playerRigidbody = playerRigidbody;

            foreach (var interactiveObject in interactiveObjects)
            {
                if (interactiveObject is SpeedBost speedBost)
                    speedBost.OnInteraction += SpeedBostOnInteraction;

                if (interactiveObject is SlowTrap slowTrap)
                    slowTrap.OnInteraction += SlowTrapOnInteraction;
            }
        }

        private void SlowTrapOnInteraction(InteractiveObject interactiveObject)
        {
            if (!_player.IsInvulnerability)
            {
                SlowTrap slowTrap = interactiveObject as SlowTrap;
                float newSpeed = _player.InitialSpeed * slowTrap.SpeedMultiplier;
                _player.SetSpeed(newSpeed, slowTrap.TrapDuration);
                _effectDuration = slowTrap.TrapDuration;
            }
        }

        private void SpeedBostOnInteraction(InteractiveObject interactiveObject)
        {
            SpeedBost speedBost = interactiveObject as SpeedBost;
            float newSpeed = _player.InitialSpeed * speedBost.SpeedMultiplier;
            _player.SetSpeed(newSpeed, speedBost.BostDuration);
            _effectDuration = speedBost.BostDuration;
        }

        public void Update(float deltaTime)
        {
            Move();
            ResetSpeed(deltaTime);
        }

        private void ResetSpeed(float deltaTime)
        {
            if (_effectDuration <= 0)
            {
                _player.ResetSpeed();
            }
            else
            {
                _effectDuration -= deltaTime;
            }
        }

        private void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            _playerRigidbody.AddForce(movement * _player.CurrentSpeed);
        }
    }
}
