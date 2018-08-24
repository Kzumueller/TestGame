using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ComputerPlayer : MonoBehaviour {

    private State state = State.Waypoint;
    private Waypoints waypoints;
    private RandomMovement randomMovement;
    private PathNavigation navigation;
    private Timer timer;
    private Vector3 lastPosition;

	// Use this for initialization
	private void Start () {
        waypoints = GetComponent<Waypoints>();
        randomMovement = GetComponent<RandomMovement>();
        navigation = GetComponent<PathNavigation>();
        waypoints.GoToRandomWaypoint();
	}
	
	//switches between states, (de)activates other scripts to act accordingly
	private void Update () {
        switch (state) {
            case State.Waypoint:
                if (!Stopped()) break;

                state = State.Wander;
                waypoints.enabled = false;
                navigation.enabled = false;
                randomMovement.enabled = true;
                timer = new Timer(5f);
                break;

            case State.Wander:
                if (!timer.Finished(Time.deltaTime)) break;

                state = State.Waypoint;
                randomMovement.enabled = false;
                navigation.enabled = true;
                waypoints.enabled = true;
                waypoints.GoToRandomWaypoint();
                break;
        }
	}

    //returns whether out bot is standing still, i.e. its position in the last frame is the same as its current one
    private bool Stopped() {
        if (lastPosition == transform.position) {
            return true;
        }

        lastPosition = transform.position;

        return false;
    }
}
