using System;

namespace Pong.Game
{
    public static class GameEvents
    {        
        public static event Action<ScoreZoneSide> PointScored;

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

