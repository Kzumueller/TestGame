using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTransition : Transition {

    private float minTime;
    private float maxTime;

    private static System.Random random = new System.Random();
    private Timer timer;

    public RandomTransition(string nextState, int minimumDuration, int maximumDuration) : base(nextState) {
        minTime = minimumDuration;
        maxTime = maximumDuration;
    }

    //instantiates a new timer with a random time
    public override void Initialize() => timer = new Timer(GetTime());

    //returns a random float between minTime and maxTime
    private float GetTime() => (float)random.NextDouble() * (maxTime - minTime) + minTime;

    //returns whether the timer has finished
    public override bool StateChanged() => timer.Finished(Time.deltaTime);
}
