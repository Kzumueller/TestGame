using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    public Transform[] waypoints;

    private static System.Random random = new System.Random();
    private PathNavigation navigation;

    private void Awake() {
        navigation = GetComponent<PathNavigation>();
    }

    // Use this for initialization
    void Start () {
        GoToRandomWaypoint();
	}

    public void GoToRandomWaypoint() {
        GoToWaypoint(random.Next(0, waypoints.Length));
    }

    public void GoToWaypoint(int index) {
        navigation.StartSearch(waypoints[index].position);
    }
}
