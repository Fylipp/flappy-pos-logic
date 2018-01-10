using UnityEngine;

namespace FlappyPosLogic {
    [RequireComponent(typeof(Collider2D))]
    public class Obstacle : MonoBehaviour {
        private void OnCollisionEnter2D(Collision2D other) {
            var bird = other.gameObject.GetComponent<Bird>();

            if (bird != null) {
                bird.Die();
            }
        }
    }
}
