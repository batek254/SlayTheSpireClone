using Godot;
using System;

public partial class CardClickedState : CardState
{
    public override void Enter()
    {
        cardUI.color.Color = Colors.Orange;
		cardUI.state.Text = "Clicked";
		cardUI.GetNode<Area2D>("DropPointDetector").Monitoring = true;
		//cardUI.dropPointDetector.Monitoring = true; // add drop point detector
    }

	public override void OnInput(InputEvent @event)
	{
		if (@event is InputEventMouseMotion)
		{
			EmitSignal(CardState.SignalName.TransitionRequested, this.state.ToString(), State.Dragging.ToString()); // is ToString() necessary?
		}
	}
}
