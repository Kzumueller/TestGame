using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State {

    public IdleState() : base("Idle") { }

    // this class is called IdleState for a reason
    public override void Enter() => base.Enter();

    public override void Exit() {}
}
