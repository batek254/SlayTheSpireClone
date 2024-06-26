using Godot;
using System;

public partial class CardReleasedState : CardState
{
	public override void Enter()
	{
		cardUI.color.Color = Colors.DarkViolet;
		cardUI.state.Text = "Released";
	}
}
