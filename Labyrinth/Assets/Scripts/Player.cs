﻿using UnityEngine;


namespace Labyrinth
{

    public class Player : MonoBehaviour
    {
        public float InitialSpeed
        {
            get
            {
                return _initialSpeed;
            }
        }

        public bool IsInvulnerability
        {
            get
            {
                return _isInvulnerability;
            }
        }

        [SerializeField] private float _speed = 3.0f;

        private Rigidbody _rigidbody;
        private Renderer _renderer;

        private float _initialSpeed;
        private bool _isInvulnerability;
        private Color _initialColor;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _renderer = GetComponent<Renderer>();
            _initialColor = _renderer.material.color;
            _initialSpeed = _speed;
        }

        private void Update()
        {
            Move();
        }

        protected void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            _rigidbody.AddForce(movement * _speed);
        }

        public void SetTemporarySpeed(float speed, float time)
        {
            _speed = speed;
            Invoke(nameof(ResetSpeed), time);
        }

        public void SetTemporaryInvulnerability(float time)
        {
            _isInvulnerability = true;
            _renderer.material.color = Color.green;
            Invoke(nameof(ResetInvulnerability), time);
        }

        private void ResetSpeed()
        {
            _speed = _initialSpeed;
        }

        private void ResetInvulnerability()
        {
            _speed = _initialSpeed;
            _renderer.material.color = _initialColor;
        }
    }
}
