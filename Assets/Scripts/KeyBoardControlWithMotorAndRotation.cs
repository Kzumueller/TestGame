using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardControlWithMotorAndRotation : KeyBoardControl {

    public float rotationSpeed = 90f;

    private CharacterMotor motor;

    private static Dictionary<KeyCode, float> rotations = new Dictionary<KeyCode, float>() {
        { KeyCode.LeftArrow, -1f},
        { KeyCode.RightArrow, 1f}
    };

    public float GetRotation() {
        foreach (var key in rotations.Keys) {
            if (Input.GetKey(key)) {
                return rotations[key];
            }
        }

        return 0f;
    }

	// Use this for initialization
	void Start () {
        motor = GetComponent<CharacterMotor>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(transform.up * GetRotation() * rotationSpeed * Time.deltaTime);

        motor.inputMoveDirection = transform.rotation * GetDirection();

        motor.inputJump = Input.GetKey(KeyCode.Space);
	}
}
