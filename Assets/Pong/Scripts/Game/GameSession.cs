using Pong.Difficulty;
using Pong.Input;

namespace Pong.Game
{
    public static class GameSession
    {
        private static DifficultyLevel _difficultyLevel;
        public static DifficultyLevel DifficultyLevel => _difficultyLevel;
     

        private static RightPaddleMode _paddleMode;
        public static RightPaddleMode PaddleMode => _paddleMode;


        public static void SetDifficultyLevel(DifficultyLevel difficultyLevel)
        {
            _difficultyLevel = difficultyLevel;
        }

        public static void SetRightPaddleMode(RightPaddleMode paddleMode)
        {
            _paddleMode = paddleMode;
        }
    }
}


