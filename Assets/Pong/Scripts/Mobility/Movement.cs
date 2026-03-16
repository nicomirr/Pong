using UnityEngine;

using Pong.Paddle;

namespace Pong.Mobility
{
    public class Movement : MonoBehaviour, IDirectionChanger, IYPositionProvider
    {
        [SerializeField] private float _speed;
        
        private ICheckLimits _checkLimits;
        
        private Transform _transform;
        private Vector3 _moveDirection;

        public float YPosition => this.transform.position.y;

        private void Awake()
        {
            _transform = this.transform.parent;
        }

        public void Init(ICheckLimits checkLimits)
        {
            _checkLimits = checkLimits;
        }

        public void ChangeDirection(float yDirection)
        {
            _moveDirection = new Vector3(0, yDirection, 0);
        }

        private void Update()
        {
            _transform.Translate(_moveDirection * (Time.deltaTime * _speed));
            _checkLimits.ClampFinalPosition();
        }
    }
}

