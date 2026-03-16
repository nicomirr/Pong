using UnityEngine;

namespace Pong.Paddle
{
    public class SpeedConfig : MonoBehaviour
    {
        [SerializeField] private float _speed;
        public static float Speed { get; private set; }

        private void Awake()
        {
            Speed = _speed;
        }
    }
}


