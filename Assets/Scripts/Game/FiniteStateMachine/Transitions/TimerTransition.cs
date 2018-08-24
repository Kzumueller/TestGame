using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimerTransition : Transition {
    private Timer timer;
    private float time;

    public TimerTransition(string nextState, float time) : base(nextState) {
        timer = new Timer(time);
        this.time = time;
    }

    public override bool StateChanged() {
        return timer.Finished(Time.deltaTime);
    }

    public override void Initialize()
    {
        timer = new Timer(time);
    }
}
