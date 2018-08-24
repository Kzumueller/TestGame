using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardControl : MonoBehaviour {

    public float speed = 10f;

    //Input Axes
    public static string Vertical = "Vertical";
    public static string Horizontal = "Horizontal";
    public static string Jump = "Jump";
    public static string MouseX = "Mouse X";
    public static string MouseY = "Mouse Y";

    //builds a Vector3 out horizontal and vertical input axes
    public Vector3 GetDirection() {
        return new Vector3(Input.GetAxis(Horizontal), 0f, Input.GetAxis(Vertical));
    }

    //returns whether the character pressed the jump button
    public bool GetJump() {
        return .1f < Input.GetAxis(Jump);
    }

    //returns the horizontal movement of the mouse, interpreted as rotation around the y axis
    public float GetRotationY() {         
        return Input.GetAxis(MouseX);
    }

    //returns the vertical movement of the mouse, interpreted as rotation around the x axis
    public float GetRotationX()
    {
        return Input.GetAxis(MouseY);
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(GetDirection() * speed * Time.deltaTime);
	}
}
