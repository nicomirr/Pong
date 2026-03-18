using UnityEngine;
using Pong.Mobility;
using Pong.Game;

namespace Pong.Ball
{
    public class BallMovement : MonoBehaviour, IYPositionProvider, ILaunchable
    {
        [SerializeField] private Vector2 _direction;
        [SerializeField] private Vector2 _directionNormalized;
        [SerializeField] private Vector2 _velocity;

        [SerializeField] private float _startSpeed;
        [SerializeField] private float _extraSpeed;
        [SerializeField] private float _maxExtraSpeed;

        private Rigidbody2D _rb;

        private Vector2 _previousVelocity;
        public Vector2 PreviousVelocity => _previousVelocity;

        public float YPosition => this.transform.position.y;

        private int _hitCounter;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            GameEvents.ResetBall += StopBall;
        }

        private void OnDisable()
        {
            GameEvents.ResetBall -= StopBall;
        }

        private void Start()
        {
            _hitCounter = 0;
        }

        void FixedUpdate()
        {
            _previousVelocity = _rb.linearVelocity;
        }

        public void Launch(Vector2 direction)
        {
            MoveBall(direction);
        }

        private void StopBall()
        {
            _rb.linearVelocity = Vector2.zero;
        }

        public void MoveBall(Vector2 direction)
        {
            _direction = direction;

            direction = direction.normalized;

            float ballSpeed = _startSpeed + _hitCounter * _extraSpeed;

            _directionNormalized = direction;
            _velocity = direction * ballSpeed;
            _rb.linearVelocity = direction * ballSpeed;
        }

        public void IncreaseHitCounter()
        {
            if (_hitCounter * _extraSpeed >= _maxExtraSpeed) return;

            _hitCounter++;
        }
    }
}





