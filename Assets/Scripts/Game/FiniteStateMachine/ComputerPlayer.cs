using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayer : MonoBehaviour {

    private Dictionary<string, State> states;
    private State currentState;

    //configures and adds States to the states Dictionary
    private void Start() {
        states = new Dictionary<string, State>();

        State state = new WaypointState(transform);
        state.AddTransition(new StoppedTransition("Wandering", transform));
        states.Add(state.name, state);

        state = new WanderingState(transform);
        state.AddTransition(new PlayerCloseTransition("Chasing", transform, 5f));
        state.AddTransition(new TimerTransition("Waypoint", 5f));
        state.AddTransition(new RandomTransition("Idle", 3, 7));
        states.Add(state.name, state);

        state = new ChasingState(transform);
        state.AddTransition(new PlayerFarTransition("Waypoint", transform, 5f));
        states.Add(state.name, state);

        state = new IdleState();
        state.AddTransition(new TimerTransition("Wandering", 5f));
        state.AddTransition(new PlayerCloseTransition("Chasing", transform, 5f));
        states.Add(state.name, state);

        currentState = states["Waypoint"];
        currentState.Enter();
    }

    //checks whether a transition from the currentState is due and if it is, exits it, gets the next state and enters it 
    private void Update() {
        var nextStateName = currentState.Transition();

        if (nextStateName != currentState.name) {
            currentState.Exit();
            currentState = states[nextStateName];
            currentState.Enter();
        }
    }
}
