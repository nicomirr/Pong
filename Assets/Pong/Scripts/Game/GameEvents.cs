using System;
using Pong.Score;

namespace Pong.Game
{
    public static class GameEvents
    {
        //Se dispara en ScoreZoneCollision, escucha ScoreManager
        public static event Action<ScoreZoneSide> PointScored;

        //Se dispara en ScoreZoneCollision, escuchan BallMovement y BallLauncher
        public static event Action ResetBall;

        public static void RaisePointScored(ScoreZoneSide side)
        {
            PointScored?.Invoke(side);
        }               

        public static void RaiseResetBall()
        {
            ResetBall?.Invoke();
        }
       
    }
}

