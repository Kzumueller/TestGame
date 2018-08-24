using UnityEngine;

public class PlayerCloseTransition : Transition {

    public float distance;

    private Transform parent;
    private Transform player;

    public PlayerCloseTransition(string nextState, Transform parent, float distance) : base(nextState) {
        this.parent = parent;
        this.distance = distance;

        player = GameObject.FindWithTag("Player").transform;
    }

    public override bool StateChanged() => distance > Vector3.Distance(parent.position, player.position);
}
