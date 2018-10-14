using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCheck : MonoBehaviour {

    private Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (1f > Vector3.Distance(transform.position, player.position)) {
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
	}
}
