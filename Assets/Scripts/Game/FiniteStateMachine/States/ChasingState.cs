using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : State {

    private Chase chase;
    private PathNavigation navigation;

    public ChasingState(Transform parent) : base("Chasing") {
        chase = parent.gameObject.GetComponent<Chase>();
        navigation = parent.gameObject.GetComponent<PathNavigation>();
    }

    public override void Enter() {
        base.Enter();
        navigation.enabled = true;
        chase.enabled = true;
        chase.ChasePlayer();
    }

    public override void Exit() {
        navigation.enabled = false;
        chase.enabled = false;
    }
}
