using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardControlWithMotorAndRotation : KeyBoardControl {

    public float rotationSpeed = 90f;

    private CharacterMotor motor;
    private Transform camera;

	// Use this for initialization
	void Start () {
        motor = GetComponent<CharacterMotor>();
        camera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(transform.up * GetRotationY() * rotationSpeed * Time.deltaTime);

        motor.inputMoveDirection = transform.rotation * GetDirection();
        motor.inputJump = GetJump();
	}

    private void LateUpdate()
    {
        //camera.Rotate(transform.forward * GetRotationX() * rotationSpeed * Time.deltaTime);
    }
}
