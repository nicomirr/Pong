using UnityEngine;

using Pong.Paddle;

namespace Pong.Mobility
{
    public class PaddleMovement : MonoBehaviour, IDirectionChanger, IYPositionProvider
    {
        [SerializeField] private float _speed;
        
        private Rigidbody2D _rb;
        private ICheckLimits _checkLimits;
      
        private Vector2 _moveDirection;

        public float YPosition => this.transform.position.y;

        
        public void Init(Rigidbody2D rb, ICheckLimits checkLimits)
        {
            _rb = rb;
            _checkLimits = checkLimits;
        }

        public void ChangeDirection(float yDirection)
        {
            _moveDirection = new Vector2(0, yDirection);
        }

        private void FixedUpdate()
        {
            Vector2 targetPosition = _rb.position + _moveDirection * (_speed * Time.fixedDeltaTime);
            targetPosition = _checkLimits.ClampFinalPosition(targetPosition);

            _rb.MovePosition(targetPosition);            
            
        }
    }
}

