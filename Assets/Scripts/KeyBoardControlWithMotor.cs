using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardControlWithMotor : KeyBoardControl {

    private CharacterMotor motor;

	// Use this for initialization
	void Start () {
        motor = GetComponent<CharacterMotor>();
	}
	
	// Update is called once per frame
	void Update () {
        motor.inputMoveDirection = GetDirection();
        motor.inputJump = GetJump();
	}
}
