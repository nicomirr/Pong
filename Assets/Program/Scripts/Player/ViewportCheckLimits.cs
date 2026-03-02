using UnityEngine;

public class ViewportCheckLimits : ICheckLimits
{
    private readonly ViewportLimits _viewportLimits;
    private readonly Transform _transform;
    private readonly Camera _camera;

    public ViewportCheckLimits(Transform transform, Camera camera, ViewportLimits viewportLimits)
    {
        _transform = transform;
        _camera = camera;
        _viewportLimits = viewportLimits;
    }

    public void ClampFinalPosition()
    {
        Vector3 viewportPointPosition = _camera.WorldToViewportPoint(_transform.position);
        
        viewportPointPosition.y = Mathf.Clamp(viewportPointPosition.y,
            _viewportLimits.MinY, _viewportLimits.MaxY);

        _transform.position = _camera.ViewportToWorldPoint(viewportPointPosition);
    }
}

