using UnityEngine;

using Pong.Difficulty;
using Pong.Game;

namespace Pong.Paddle.Mobility
{
    public class PaddleMovement : MonoBehaviour, IDirectionChanger, IYPositionProvider, IPaddleDifficultyConfigurator, IGameplayController
    {
        [SerializeField] private float _speed;
        
        private Rigidbody2D _rb;
        private ICheckLimits _checkLimits;
      
        private Vector2 _moveDirection;

        public float YPosition => this.transform.position.y;

        private bool _canMove;
        
        public void Init(Rigidbody2D rb, ICheckLimits checkLimits)
        {
            _rb = rb;
            _checkLimits = checkLimits;
        }

        public void EnableGameplay()
        {
            _canMove = true;
        }

        public void DisableGameplay()
        {
            _canMove = false;
        }

        public void ApplyPaddleDifficultyConfig(float speed)
        {
            _speed = speed;
        }

        public void ChangeDirection(float yDirection)
        {
            _moveDirection = new Vector2(0, yDirection);
        }

        private void FixedUpdate()
        {
            if (!_canMove) return;

            Vector2 targetPosition = _rb.position + _moveDirection * (_speed * Time.fixedDeltaTime);
            targetPosition = _checkLimits.ClampFinalPosition(targetPosition);

            _rb.MovePosition(targetPosition);            
            
        }

        
    }
}

