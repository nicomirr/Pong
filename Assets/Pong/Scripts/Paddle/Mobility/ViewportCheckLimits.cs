using UnityEngine;

namespace Pong.Paddle.Mobility
{
    public class ViewportCheckLimits : ICheckLimits
    {
        private readonly ViewportLimits _viewportLimits;
        
        private readonly Camera _camera;

        public ViewportCheckLimits(Camera camera, ViewportLimits viewportLimits)
        {
            _camera = camera;
            _viewportLimits = viewportLimits;
        }

        public Vector2 ClampFinalPosition(Vector2 position)
        {
            Vector3 viewportPointPosition = _camera.WorldToViewportPoint(position);

            viewportPointPosition.y = Mathf.Clamp(viewportPointPosition.y,
                _viewportLimits.MinY, _viewportLimits.MaxY);

            return _camera.ViewportToWorldPoint(viewportPointPosition);
        }

    }
}



