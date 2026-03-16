using Pong.Mobility;
using Pong.Spatial;

namespace Pong.Input.AI
{
    public class AIInputAdapter : IInput
    {
        private readonly IDirectionChanger _directionChanger;
        private readonly IYPositionProvider _ballYPosProvider;
        private readonly IYPositionProvider _paddleYPosProvider;
        private readonly IPaddleBoundsProvider _paddleBoundsProvider;       

        public AIInputAdapter(IDirectionChanger directionChanger, IYPositionProvider ballYPosProvider, IYPositionProvider paddleYPosProvider,
            IPaddleBoundsProvider paddleBoundsProvider)
        {
            _directionChanger = directionChanger;
            _ballYPosProvider = ballYPosProvider;
            _paddleYPosProvider = paddleYPosProvider;      
            _paddleBoundsProvider = paddleBoundsProvider;  
        }

        public void ChangeDirection()
        {
            float paddleCenter = _paddleYPosProvider.YPosition;
            float ballYPosition = _ballYPosProvider.YPosition;
            float chaseBuffer = _paddleBoundsProvider.HalfHeight;

            float direction = 0f;

            if (ballYPosition <= paddleCenter - chaseBuffer)
                direction = -1f;

            else if (ballYPosition >= paddleCenter + chaseBuffer)
                direction = 1f;

            _directionChanger.ChangeDirection(direction);
                        
        }
                
    }
}

