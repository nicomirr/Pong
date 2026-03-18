using UnityEngine;

using Pong.Tags;

namespace Pong.Ball
{
    public class BallCollision : MonoBehaviour
    {
        [SerializeField] private BounceModifier _bounceModifier;
        [SerializeField] private BallMovement _ballMovement;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Vector2 newVelocity = new Vector2(0, 0);

            if (collision.gameObject.TryGetComponent<PaddleTag>(out _))
            {                
                Vector2 paddlePosition = collision.transform.position;
                float paddleHalfHeight = collision.bounds.size.y * 0.5f;

                newVelocity = BallBounce.PaddleBounce(this.transform.position, paddlePosition, paddleHalfHeight, _bounceModifier.BounceFactor);

                _ballMovement.IncreaseHitCounter();
            }
            else if (collision.gameObject.TryGetComponent<TopWallTag>(out _))
            {
                newVelocity = BallBounce.WallBounce(_ballMovement.PreviousVelocity, Vector2.up);
            }
            else if (collision.gameObject.TryGetComponent<BottomWallTag>(out _))
            {
                newVelocity = BallBounce.WallBounce(_ballMovement.PreviousVelocity, Vector2.down);
            }

            _ballMovement.MoveBall(newVelocity);
        }
               

    }
}


