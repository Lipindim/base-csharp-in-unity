﻿using UnityEngine;


namespace Labyrinth
{

    public sealed class CameraController : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;

        private GameObject _player;


        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        private void LateUpdate()
        {
            transform.position = _player.transform.position + _offset;
        }
    }
}