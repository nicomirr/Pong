using UnityEngine;

namespace Pong.Difficulty
{
    [CreateAssetMenu(fileName = "DifficultyConfig", menuName = "Scriptable Objects/DifficultyConfig")]
    public class DifficultyConfig : ScriptableObject
    {
        [Header("Paddle")]
        [SerializeField] private float _playerSpeed;
        public float PlayerSpeed => _playerSpeed;

        [SerializeField] private float _aiSpeed;
        public float AISpeed => _aiSpeed;


        [Header("Ball")]
        [SerializeField] private float _ballStartSpeed;
        public float BallStartSpeed => _ballStartSpeed;

        [SerializeField] private float _ballExtraSpeed;
        public float BallExtraSpeed => _ballExtraSpeed;

        [SerializeField] private float _ballMaxSpeed;
        public float BallMaxSpeed => _ballMaxSpeed;

    }
}


