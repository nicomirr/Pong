using UnityEngine;
using System.Collections;
using Pong.Game;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private Vector2 _initialBallPos;
    [SerializeField] private Rigidbody2D _ballRb;

    [SerializeField] private float _ballResetDelay;
    [SerializeField] private float _launchDelay;
    
    [SerializeField] private float _minYDir;
    [SerializeField] private float _maxYDir;

    [SerializeField] private MonoBehaviour _launchableMonobehaviour;
    private ILaunchable _launchable;

    private void Awake()
    {
        _launchable = _launchableMonobehaviour as ILaunchable;
    }

    private void OnEnable()
    {
        GameEvents.ResetBall += BeginLaunch;
    }

    private void OnDisable()
    {
        GameEvents.ResetBall -= BeginLaunch;
    }

    private void Start()
    {
        //cambiar luego
        BeginLaunch();
    }

    public void BeginLaunch()
    {
        StartCoroutine(LaunchRoutine());
    }

    private IEnumerator LaunchRoutine()
    {
        yield return new WaitForSeconds(_ballResetDelay);

        _ballRb.position = _initialBallPos;

        yield return new WaitForSeconds(_launchDelay);

        int randomX = Random.Range(0, 2);
        randomX = randomX == 0 ? -1 : 1;

        float randomY = Random.Range(_minYDir, _maxYDir);

        Vector2 launchDirection = new Vector2(randomX, randomY);

        _launchable.Launch(launchDirection);
    }
}
