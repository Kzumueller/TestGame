using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardControl : MonoBehaviour {

    public float speed = 10f;

    private static Dictionary<KeyCode, Vector3> directions = new Dictionary<KeyCode, Vector3>() {
        { KeyCode.W, new Vector3(0f, 0f, 1f)},
        { KeyCode.A, new Vector3(-1f, 0f, 0f)},
        { KeyCode.S, new Vector3(0f, 0f, -1f)},
        { KeyCode.D, new Vector3(1f, 0f, 0f)},
    };

    public Vector3 GetDirection() {
        foreach (var key in directions.Keys) {
            if (Input.GetKey(key)) {
                return directions[key];
            }
        }

        return Vector3.zero;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(GetDirection() * speed * Time.deltaTime);
	}
}
