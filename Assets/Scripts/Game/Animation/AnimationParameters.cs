using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationParameters : MonoBehaviour {

    private Animator animator;
    private Vector3 lastPosition;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        var speed = Vector3.Distance(transform.position, lastPosition) / Time.deltaTime;

        animator.SetFloat("Speed", speed);
        lastPosition = transform.position;
	}
}
