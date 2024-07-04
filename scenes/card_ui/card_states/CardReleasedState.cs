using Godot;
using System;

public partial class CardReleasedState : CardState
{
	public bool played;

	public override void Enter()
	{
		cardUI.color.Color = Colors.DarkViolet;
		cardUI.state.Text = "Released";

		played = false;

		if (cardUI.targets.Count > 0)
		{
			played = true;
			cardUI.targets.ForEach(target => GD.Print(target.Name.ToString()));
		}
	}

    public override void OnInput(InputEvent @event)
    {
        if (played)
		{
			return;
		}

		EmitSignal(CardState.SignalName.TransitionRequested, this.state.ToString(), State.Base.ToString());
    }
}
