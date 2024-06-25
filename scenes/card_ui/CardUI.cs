using Godot;
using System;

public partial class CardUI : Control
{
    [Signal]
    public delegate void ReparentRequestedEventHandler(CardUI whichCardUI);

    public ColorRect color;
    public Label state;
    public Area2D dropPointDetector;

    public override void _Ready()
    {
        color = GetNode<ColorRect>("ColorRect");
        state = GetNode<Label>("State");
    }
}
