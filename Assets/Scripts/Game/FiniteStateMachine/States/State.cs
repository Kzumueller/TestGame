using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class State {

    public readonly string name;
    protected List<Transition> transitions;

    public State(string name) {
        this.name = name;
        transitions = new List<Transition>();
    }

    public void AddTransition(Transition transition) {
        transitions.Add(transition);
    }

    //iterates over all held transitions and returns the name of the next state
    public string Transition() {
        foreach (var transition in transitions) {
            if (transition.StateChanged()) {
                return transition.nextState;
            }
        }

        return name;
    }

    //does everything needed to initialize a state when it's entered
    public virtual void Enter() => transitions.ForEach(transition => transition.Initialize());

    //cleans up a state so it can later be re-entered
    public abstract void Exit();
}