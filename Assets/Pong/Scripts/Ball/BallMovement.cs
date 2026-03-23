using UnityEngine;
using Pong.Paddle.Mobility;
using Pong.Game;
using Pong.Difficulty;

namespace Pong.Ball
{
    public class BallMovement : MonoBehaviour, IYPositionProvider, ILaunchable, IBallDifficultyConfigurator
    {        
        private Rigidbody2D _rb;

        private Vector2 _previousVelocity;
        public Vector2 PreviousVelocity => _previousVelocity;

        private float _startSpeed;
        private float _extraSpeed;
        private float _maxSpeed;

        private float _speed;

        public float YPosition => this.transform.position.y;

        private int _hitCounter;

        public void ApplyBallDifficultyConfig(DifficultyConfig config)
        {
            _startSpeed = config.BallStartSpeed;
            _extraSpeed = config.BallExtraSpeed;
            _maxSpeed = config.BallMaxSpeed;            
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }       
          
        void FixedUpdate()
        {
            _previousVelocity = _rb.linearVelocity;
        }

        public void Launch(Vector2 direction)
        {
            _hitCounter = 0;
            MoveBall(direction);
        }

        public void StopBall()
        {
            _rb.linearVelocity = Vector2.zero;
        }

        public void MoveBall(Vector2 direction)
        {           
            direction = direction.normalized;

            _speed = _startSpeed + _hitCounter * _extraSpeed;
            _speed = Mathf.Clamp(_speed, _startSpeed, _maxSpeed);

            _rb.linearVelocity = direction * _speed;
        }

        public void IncreaseHitCounter()
        {
            if (_speed >= _maxSpeed) return;
            _hitCounter++;
        }        
    }
}





