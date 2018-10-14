using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DebugHotKeys : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftControl)){
            if (Input.GetKey(KeyCode.L)) {
                LogPositions("Light");
            }

            if (Input.GetKey(KeyCode.G)) {
                LogPositions("Goal");
            }
        }
        
	}

    // finds all GameObjects tagged "Light" and logs their position
    public void LogPositions(string tag) {
        GameObject.FindGameObjectsWithTag(tag).ToList().ForEach(
            gameObject => Debug.Log($"{gameObject.name}: {gameObject.transform.position}")
            );
    }
}
