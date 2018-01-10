using UnityEngine;

namespace FlappyPosLogic {
    [RequireComponent(typeof(Collider2D))]
    public class Gate : MonoBehaviour {
        public Gate Next { get; set; }

        private void OnTriggerExit2D(Collider2D other) {
            var bird = other.GetComponent<Bird>();

            if (bird != null) {
                bird.NextGate = Next;
            }
        }
    }
}
