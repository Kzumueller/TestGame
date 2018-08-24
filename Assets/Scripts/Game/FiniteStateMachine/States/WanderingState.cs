using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WanderingState : State {

    private RandomMovement randomMovement;

    public WanderingState(Transform parent) : base("Wandering") {
        randomMovement = parent.gameObject.GetComponent<RandomMovement>();
    }

    public override void Enter() {
        base.Enter();
        randomMovement.enabled = true;
    }

    public override void Exit() {
        randomMovement.enabled = false;
    }
}
