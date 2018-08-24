using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardControlWithMotorAndRotation : KeyBoardControl {

    public float rotationSpeed = 90f;

    private CharacterMotor motor;

	// Use this for initialization
	void Start () {
        motor = GetComponent<CharacterMotor>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(transform.up * GetRotationY() * rotationSpeed * Time.deltaTime);

        motor.inputMoveDirection = transform.rotation * GetDirection();
        motor.inputJump = GetJump();
	}
}
