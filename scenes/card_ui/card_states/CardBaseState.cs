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
		cardUI.color.Color = Colors.WebGreen;
		cardUI.state.Text = "Base";
		cardUI.PivotOffset = new Vector2(0, 0);
	}

    public override void OnGUIInput(InputEvent @event)
    {
        if (@event.IsActionPressed("left_mouse"))
		{
			cardUI.PivotOffset = cardUI.GetGlobalMousePosition() - cardUI.GlobalPosition;
			EmitSignal(CardState.SignalName.TransitionRequested, this.state.ToString(), State.Clicked.ToString()); // is ToString() necessary?
		}
    }
}
