using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaypointState : State {

    private Waypoints waypoints;
    private PathNavigation navigation;

    public WaypointState(Transform parent) : base("Waypoint") {
        waypoints = parent.gameObject.GetComponent<Waypoints>();
        navigation = parent.gameObject.GetComponent<PathNavigation>();
    }

    public override void Enter() {
        base.Enter();

        navigation.enabled = true;
        waypoints.enabled = true;
        waypoints.GoToRandomWaypoint();
    }

    public override void Exit() {
        navigation.enabled = false;
        waypoints.enabled = false;
    }
}