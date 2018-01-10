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
            
            if (Input.GetKeyDown(KeyCode.Alpha4)) {
                Time.timeScale = 4;
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha5)) {
                Time.timeScale = 5;
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha6)) {
                Time.timeScale = 6;
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha7)) {
                Time.timeScale = 7;
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha8)) {
                Time.timeScale = 8;
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha9)) {
                Time.timeScale = 9;
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha0)) {
                Time.timeScale = 10;
            }
        }
    }
}
