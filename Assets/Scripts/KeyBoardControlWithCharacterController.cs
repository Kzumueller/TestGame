using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardControlWithCharacterController : KeyBoardControl {

    private CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        var test = GetComponent("CharacterMotor");
        var breakPoint = true;
    }
	
	// Update is called once per frame
	void Update () {
        controller.Move(GetDirection() * speed * Time.deltaTime);
	}
}
