using System;
using UnityEngine;

namespace FlappyPosLogic {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bird : MonoBehaviour {
        public Manager Manager { get; set; }
        public bool Alive { get; set; }

        public Gate NextGate { get; set; }

        public Vector2 OffsetToNextGate {
            get { return NextGate.transform.position - transform.position; }
        }

        public float Score {
            get { return transform.position.x; }
        }

        public Network Network { get; set; }

        [SerializeField] private float _verticalVelocity = 1;
        [SerializeField] private float _jumpVelocity = 10;

        private Rigidbody2D _rb;

        public Bird() {
            Alive = true;
        }

        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update() {
            _rb.velocity = new Vector2(_verticalVelocity, _rb.velocity.y);

            if (SimulateBrain()) {
                Jump();
            }

            if (Math.Abs(transform.position.y) >= 5) {
                Die();
            }
        }

        public void Jump() {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpVelocity);
        }

        public void Die() {
            Alive = false;
            gameObject.SetActive(false);
        }

        private bool SimulateBrain() {
            if (NextGate == null) {
                return false;
            }
            
            var offset = OffsetToNextGate;
            var input = new[] {offset.x, offset.y};
            return Network.Calculate(input)[0] > .5f;
        }
    }
}
