using Godot;
using System;

public partial class CardStateMachine : Node
{
    [Export]
    private CardState initialState;

    private CardState currentState;
    private CardState state; // singleton for state
    private Godot.Collections.Dictionary states;
    private int i = 0;


    public void Init(CardUI card)
    {
        states = new Godot.Collections.Dictionary();
        foreach (Node AChild in GetChildren())
        {
            if (AChild is CardState)
            {
                //CardState state = (CardState)AChild;
                //state = GetNode<CardState>("/root/card_ui/card_states/CardState");
                state = (CardState)AChild;
                //states = new Godot.Collections.Dictionary();
                states.Add(state.state.ToString(), state);
                state.TransitionRequested += OnTransitionRequested;
                state.cardUI = card;
            }
        }

        if (initialState != null)
        {
            initialState.Enter();
            currentState = initialState;
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

    private void OnTransitionRequested(string from, string to) // string or State?
    {
        if (from != currentState.state.ToString())
        {
            GD.PrintErr("Transition requested from a state that is not the current state");
            return;
        }
    
        CardState newState = (CardState)states[to];
        if (newState == null)
        {
            GD.PrintErr("State not found: " + to);
            return;
        }
    
        //if (currentState != null)
        //{
        //    GD.Print("Exiting state: " + currentState.state.ToString());
        //    currentState.Exit();
        //}
    
        newState.Enter();
        currentState = newState;
    }

}
