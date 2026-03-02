using UnityEngine;

public class MovementInstaller : MonoBehaviour
{
    [SerializeField] private PaddleType _paddleType;
    [SerializeField] private ViewportLimits _playerViewportLimits;

    [SerializeField] private Transform _paddle;
    [SerializeField] private Movement _movement;

    private void Awake()
    {
        _movement.Init(GetCheckLimitsStrategy());
    }

    private ICheckLimits GetCheckLimitsStrategy()
    {
        if (_paddleType == PaddleType.AI)
        {
            return new ViewportCheckLimits(_paddle, Camera.main, _playerViewportLimits);
        }

        return new ViewportCheckLimits(_paddle, Camera.main, _playerViewportLimits);
    }
    
}
