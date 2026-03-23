using UnityEngine;
using System.Collections;
using Pong.Game;

public class BallLauncher : MonoBehaviour, IGameplayController
{
    [SerializeField] private Vector2 _initialBallPos;
    [SerializeField] private Rigidbody2D _ballRb;

    [SerializeField] private float _launchDelay;
    
    [SerializeField] private float _minYDir;
    [SerializeField] private float _maxYDir;

    [SerializeField] private MonoBehaviour _launchableMonobehaviour;
    private ILaunchable _launchable;

    private bool _canLaunch;

    private void Awake()
    {
        _launchable = _launchableMonobehaviour as ILaunchable;
    }

    public void EnableGameplay()
    {
        _canLaunch = true;
    }

    public void DisableGameplay()
    {
        _canLaunch = false;
    }
        
    private void Start()
    {        
        Launch();
    }    

    public void Launch()
    {
        if (!_canLaunch) return;

        StartCoroutine(LaunchRoutine());
    }

    private IEnumerator LaunchRoutine()
    {        
        _ballRb.position = _initialBallPos;

        yield return new WaitForSeconds(_launchDelay);

        int randomX = Random.Range(0, 2);
        randomX = randomX == 0 ? -1 : 1;

        float randomY = Random.Range(_minYDir, _maxYDir);

        Vector2 launchDirection = new Vector2(randomX, randomY);

        _launchable.Launch(launchDirection);
    }

    
}
