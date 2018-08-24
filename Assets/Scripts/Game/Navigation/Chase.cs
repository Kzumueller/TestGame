using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    private Transform player;
    private PathNavigation navigation;
    private Vector3 lastPosition;

    private void Awake() {
        player = GameObject.FindWithTag("Player").transform;
        navigation = GetComponent<PathNavigation>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update () {
        if (transform.position == lastPosition) {
            ChasePlayer();
        }

        lastPosition = transform.position;
	}

    public void ChasePlayer() {
        navigation.StartSearch(player.position);
    }
}
