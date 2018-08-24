using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class StoppedTransition : Transition {

    private Transform transform;
    private Vector3 lastPosition;

    public StoppedTransition(string nextState, Transform transform) : base(nextState) {
        this.transform = transform;
    }

    public override bool StateChanged() {
        if (lastPosition == transform.position) {
            return true;
        }

        lastPosition = transform.position;

        return false;
    }
}