using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition {

    public readonly string nextState;

    public Transition(string next) {
        nextState = next;
    }

    public virtual void Initialize() {}

    public abstract bool StateChanged();
}