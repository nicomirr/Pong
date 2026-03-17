using UnityEngine;

using Pong.Tags;

namespace Pong.Ball
{
    public class BallCollision : MonoBehaviour
    {
        [SerializeField] private BounceModifier _bounceModifier;
        [SerializeField] private BallMovement _ballMovement;       

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Vector2 newVelocity;

            if (collision.gameObject.TryGetComponent<PaddleTag>(out _))
            {
                Vector2 paddlePosition = collision.transform.position;
                float paddleHalfHeight = collision.collider.bounds.size.y * 0.5f;
                ContactPoint2D contact = collision.GetContact(0);

                newVelocity = BallBounce.PaddleBounce(this.transform.position, paddlePosition, paddleHalfHeight, _bounceModifier.BounceFactor);

                _ballMovement.IncreaseHitCounter();

                

                _ballMovement.MoveBall(newVelocity);
            }
            else if (collision.gameObject.TryGetComponent<WallTag>(out _))
            {
                ContactPoint2D contact = collision.GetContact(0);

                //collision.relativeVelocity?
                newVelocity = BallBounce.WallBounce(_ballMovement.PreviousVelocity, contact.normal);

                transform.position = (Vector2)transform.position + contact.normal * 0.02f;

                _ballMovement.MoveBall(newVelocity);

            }
        }
    }
}


