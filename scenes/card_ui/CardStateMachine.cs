using Godot;
using System;

public partial class CardStateMachine : Node
{
    [Export]
    public CardState initialState;
    
    public CardState currentState;
    public Godot.Collections.Dictionary states;
    public CardState state;

    public void Init(CardUI card)
    {
        states = new Godot.Collections.Dictionary();
        foreach (Node AChild in GetChildren())
        {
            if (AChild is CardState)
            {
                //CardState state = (CardState)AChild;
                state = (CardState)AChild;
                //states = new Godot.Collections.Dictionary();
                states.Add(state.state.ToString(), state);
                state.TransitionRequested += OnTransitionRequested;
                state.cardUI = card;
            }
        }

        if (initialState != null)
        {
            currentState = initialState;
            currentState.Enter();
        }
    }

    public void OnInput(InputEvent @event)
    {
        if (currentState != null)
        {
            currentState.OnInput(@event);
        }
    }

    public void OnGUIInput(InputEvent @event)
    {
        if (currentState != null)
        {
            currentState.OnGUIInput(@event);
        }
    }

    public void OnMouseEntered()
    {
        if (currentState != null)
        {
            currentState.OnMouseEntered();
        }
    }

    public void OnMouseExited()
    {
        if (currentState != null)
        {
            currentState.OnMouseExited();
        }
    }

    private void OnTransitionRequested(CardState.State from, CardState.State to)
    {
        GD.Print("Transition requested from: " + from.ToString() + " to: " + to.ToString());
        if (from != currentState.state)
        {
            GD.PrintErr("Transition requested from a state that is not the current state");
            return;
        }
    
        CardState newState = (CardState)states[to.ToString()];
        GD.Print("Transition requested from: " + from.ToString() + " to: " + to.ToString());
        if (newState == null)
        {
            GD.PrintErr("State not found: " + to.ToString());
            return;
        }
    
        //if (currentState != null)
        //{
        //    GD.Print("Exiting state: " + currentState.state.ToString());
        //    currentState.Exit();
        //}
    
        newState.Enter();
        currentState = newState;
        GD.Print("Entering state: " + currentState.state.ToString());
    }

}
