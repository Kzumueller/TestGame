using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private void OnGUI() {
        Cursor.visible = true;

        GUI.skin.GetStyle("Label").fontSize = 30;
        GUI.Label(new Rect(Screen.width / 2 - 160f, Screen.height / 2 - 50f, 320, 100), "        Game Over \ndon't get caught, man");

        if (GUI.Button(new Rect(10, 10, 70, 30), "Try again")) {
            SceneManager.LoadScene("Game");
        }

        if (GUI.Button(new Rect(10, 50, 60, 30), "Quit")) {
            Application.Quit();
        }
    }
}
