using Godot;
using System;

public partial class CardBaseState : CardState
{
	public override async void Enter()
	{
		GD.Print("CardBaseState.Enter()");
		if (!cardUI.IsNodeReady())
		{
			await ToSignal(cardUI, "ready");
		}

		// https://www.reddit.com/r/godot/comments/11p0il6/godot_4_c_signals_issue/
		//EmitSignal(CardUI.SignalName.ReparentRequested, cardUI);
		cardUI.EmitSignal(CardUI.SignalName.ReparentRequested, cardUI);
		cardUI.color.Color = Colors.WebGreen;
		cardUI.state.Text = "Base";
		cardUI.PivotOffset = new Vector2(0, 0);
	}

    public override void OnGUIInput(InputEvent @event)
    {
        if (@event.IsActionPressed("left_mouse"))
		{
			cardUI.PivotOffset = cardUI.GetGlobalMousePosition() - cardUI.GlobalPosition;
			GD.Print("from " + this.state.ToString() + " to " + State.Clicked.ToString());
			EmitSignal(CardState.SignalName.TransitionRequested, this.state.ToString(), State.Clicked.ToString()); // is ToString() necessary?
			GD.Print("from " + this.state.ToString() + " to " + State.Clicked.ToString());
		}
    }
}
