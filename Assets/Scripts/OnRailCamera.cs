using System.Linq;
using UnityEngine;

namespace FlappyPosLogic {
    public class OnRailCamera : MonoBehaviour {
        [SerializeField] private Manager _manager;

        private void Update() {
            if (_manager.Birds != null && _manager.Birds.Length != 0) {
                var x = _manager.Birds.Select(b => b.transform.position.x).Max();
                transform.position = new Vector3(x, 0, -10);
            } else {
                transform.position = new Vector3(0, 0, -10);
            }
        }
    }
}
