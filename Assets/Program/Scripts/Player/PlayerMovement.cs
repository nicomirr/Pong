using System;
using UnityEngine;

namespace Program.Player
{
    public class PlayerMovement : MonoBehaviour, IDirectionChanger
    {
        private Transform _transform;
        private Vector3 _moveDirection;

        private void Awake()
        {
            _transform = this.transform.parent;
        }

        public void ChangeDirection(float yDirection)
        {
            _moveDirection = new Vector3(0, yDirection, 0);
        }

        private void Update()
        {
            _transform.Translate(_moveDirection * (Time.deltaTime * 5));
        }
    }
}


