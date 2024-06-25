using Godot;
using System;

[GlobalClass]
public partial class CardState : Node
{
    public enum State
    {
        Base,
        Clicked,
        Dragging,
        Aiming,
        Released
    }

    [Signal]
    public delegate void TransitionRequestedEventHandler(CardState from, State to);

    [Export]
    public State state;

    public CardUI cardUI;

    public virtual void Enter() // abstract, virtual or override (https://stackoverflow.com/questions/14728761/difference-between-virtual-and-abstract-methods)?
    {
        return;
    }

    public void Exit()
    {
        return;
    }

    public void OnInput(InputEvent @event)
    {
        return;
    }
    
    public void OnGUIInput(InputEvent @event)
    {
        return;
    }

    public void OnMouseEntered()
    {
        return;
    }

    public void OnMouseExited()
    {
        return;
    }
}
