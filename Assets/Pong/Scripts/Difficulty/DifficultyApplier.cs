using Pong.Ball;
using Pong.Game;
using Pong.Input;
using Pong.Paddle.Mobility;
using UnityEngine;

namespace Pong.Difficulty
{
    public class DifficultyApplier : MonoBehaviour
    {
        [Header("Difficulties")]
        [SerializeField] private DifficultyConfig _easyConfig;
        [SerializeField] private DifficultyConfig _normalConfig;
        [SerializeField] private DifficultyConfig _hardConfig;

        [Header("Paddles")]
        [SerializeField] private PaddleMovement _leftPaddleMovement;
        [SerializeField] private PaddleMovement _rightPaddleMovement;

        [Header("Ball")]
        [SerializeField] private BallMovement _ballMovement;


        private void Awake()
        {
            DifficultyConfig config = GetCurrentConfig();

            _leftPaddleMovement.ApplyPaddleDifficultyConfig(config.PlayerSpeed);
            _rightPaddleMovement.ApplyPaddleDifficultyConfig(GetRightPaddleSpeed(config));
            _ballMovement.ApplyBallDifficultyConfig(config);
        }

        private DifficultyConfig GetCurrentConfig()
        {
            return GameSession.DifficultyLevel switch
            {
                DifficultyLevel.Easy => _easyConfig,
                DifficultyLevel.Normal => _normalConfig,
                DifficultyLevel.Hard => _hardConfig,
                _ => throw new System.ArgumentOutOfRangeException(nameof(GameSession.DifficultyLevel), GameSession.DifficultyLevel, null)
            };
        }
        private float GetRightPaddleSpeed(DifficultyConfig config)
        {
            return GameSession.PaddleMode == RightPaddleMode.WASD
                ? config.PlayerSpeed
                : config.AISpeed;
        }
    }
}

