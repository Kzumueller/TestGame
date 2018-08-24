using UnityEngine;

public class PlayerFarTransition : PlayerCloseTransition {

    public PlayerFarTransition(string nextState, Transform parent, float distance) : base(nextState, parent, distance) { }

    // this transition being exactly the opposite of its base, a state change is easy to determine
    public override bool StateChanged() => !base.StateChanged();
}
