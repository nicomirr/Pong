using Pong.Mobility;
using System.Collections;
using UnityEngine;

namespace Pong.Ball
{
    public class BallMovement : MonoBehaviour, IYPositionProvider
    {
        [SerializeField] private Vector2 _direction;
        [SerializeField] private Vector2 _speed;

        [SerializeField] private float _launchDelayTime;

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

        private void Start()
        {
            _hitCounter = 0;
            StartCoroutine(Launch());
        }

        void FixedUpdate()
        {
            _previousVelocity = _rb.linearVelocity;
        }

        private IEnumerator Launch()
        {
            yield return new WaitForSeconds(_launchDelayTime);

            MoveBall(new Vector2(-1, 0));
        }

        public void MoveBall(Vector2 direction)
        {
            direction = direction.normalized;

            float ballSpeed = _startSpeed + _hitCounter * _extraSpeed;

            _direction = direction;
            _speed = direction * ballSpeed;

            _rb.linearVelocity = direction * ballSpeed;
        }

        public void IncreaseHitCounter()
        {
            if (_hitCounter * _extraSpeed >= _maxExtraSpeed) return;

            _hitCounter++;
        }

    }
}


