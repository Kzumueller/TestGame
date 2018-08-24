using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

    //movement speed
    public float speed = 4f;

    private CharacterController controller;

    private static System.Random random = new System.Random();

    // gets the CharacterController
    private void Awake() => controller = GetComponent<CharacterController>();

    // moves the character forward using speed
    void Update() => controller.Move(transform.forward * speed * Time.deltaTime);

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (!enabled) return;
        if ("TileMapPlane".Equals(hit.gameObject.tag)) return;

        if (-.1f > Vector3.Dot(transform.forward, hit.normal))
            transform.Rotate(transform.up * random.Next(1,3) * 90f);
    }
}
