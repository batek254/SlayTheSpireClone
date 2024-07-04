using Godot;
using System;

public partial class Hand : HBoxContainer
{
	public override void _Ready()
	{
		foreach (Node AChild in GetChildren())
		{
			CardUI cardUI = (CardUI)AChild;
			cardUI.ReparentRequested += OnCardUIReparentRequested;
		}
	}

    private void OnCardUIReparentRequested(CardUI child)
    {
        child.Reparent(this);
    }

}
