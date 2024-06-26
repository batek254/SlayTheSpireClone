using Godot;
using System;

public partial class CardUI : Control
{
    [Signal]
    public delegate void ReparentRequestedEventHandler(CardUI whichCardUI);

    public ColorRect color;
    public Label state;
    public Area2D dropPointDetector;
    public CardStateMachine cardStateMachine;

    public override void _Ready()
    {
        color = GetNode<ColorRect>("Color");
        state = GetNode<Label>("State");
        cardStateMachine = GetNode<CardStateMachine>("CardStateMachine");
        cardStateMachine.Init(this);
    }

    public override void _Input(InputEvent @event)
    {
        cardStateMachine.OnInput(@event);
    }

    public void _OnGuiInput(InputEvent @event)
    {
        cardStateMachine.OnGUIInput(@event);
    }

    public void _OnMouseEntered()
    {
        cardStateMachine.OnMouseEntered();
    }

    public void _OnMouseExited()
    {
        cardStateMachine.OnMouseExited();
    }
}
