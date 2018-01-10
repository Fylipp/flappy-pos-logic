using System.Linq;
using UnityEngine;

namespace FlappyPosLogic {
    [RequireComponent(typeof(SpriteRenderer))]
    public class RandomSprite : MonoBehaviour {
        [SerializeField] private Sprite[] _sprites;

        private void Awake() {
            if (_sprites.Length != 0) {
                GetComponent<SpriteRenderer>().sprite = _sprites[Random.Range(0, _sprites.Length)];
            }
        }
    }
}
