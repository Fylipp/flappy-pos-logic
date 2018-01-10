using UnityEngine;

namespace FlappyPosLogic {
    public class GoFaster : MonoBehaviour {
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                Time.timeScale = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                Time.timeScale = 2;
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                Time.timeScale = 3;
            }
        }
    }
}
