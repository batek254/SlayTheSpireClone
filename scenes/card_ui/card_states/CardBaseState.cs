using Godot;
using System;

public partial class CardBaseState : CardState
{
	public override async void Enter()
	{
		if (!cardUI.IsNodeReady())
		{
			await ToSignal(cardUI, "ready");
		}

		EmitSignal(CardUI.SignalName.ReparentRequested, cardUI);
		cardUI.color.Color = Colors.Green;
		cardUI.state.Text = "Base";
		cardUI.PivotOffset = new Vector2(0, 0);
	}

	
}
