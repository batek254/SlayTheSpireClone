using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class CardUI : Control
{
    [Signal]
    public delegate void ReparentRequestedEventHandler(CardUI whichCardUI);

    public ColorRect color;
    public Label state;
    public Area2D dropPointDetector;
    public CardStateMachine cardStateMachine;
    public List<Node> targets = new List<Node>();

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

    public void OnGuiInput(InputEvent @event) // delete _ prefix and update it in the Node Signals in Godot
    {
        cardStateMachine.OnGUIInput(@event);
    }

    public void OnMouseEntered()
    {
        cardStateMachine.OnMouseEntered();
    }

    public void OnMouseExited()
    {
        cardStateMachine.OnMouseExited();
    }

    public void OnDropPointDetectorAreaEntered(Area2D area)
    {
        if (!targets.Contains(area))
        {
            GD.Print(area.GetType().ToString() + " entered");
            targets = targets.Append(area).ToList();
            targets.ForEach(target => GD.Print(target.Name.ToString()));
        }
    }

    public void OnDropPointDetectorAreaExited(Area2D area)
    {
        targets.Remove(area);
    }
}
