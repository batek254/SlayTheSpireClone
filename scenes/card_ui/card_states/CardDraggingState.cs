using Godot;
using System;

public partial class CardDraggingState : CardState
{
	private const float DragMinimumThreshold = 0.05f;
	private bool minimumDragTimeElapsed = false;

    public override void Enter()
    {
		Node uiLayer = GetTree().GetFirstNodeInGroup("ui_layer");

		if (uiLayer != null)
		{
			cardUI.Reparent(uiLayer);
		}

		cardUI.color.Color = Colors.NavyBlue;
		cardUI.state.Text = "Dragging";	

		minimumDragTimeElapsed = false;
		var timer = GetTree().CreateTimer(DragMinimumThreshold, false);
		timer.Connect("timeout", Callable.From(() => minimumDragTimeElapsed = true));
    }

    public override void OnInput(InputEvent @event)
    {
		if (@event is InputEventMouseMotion)
		{
			//InputEvent mouseMotion = @event;
			cardUI.GlobalPosition = cardUI.GetGlobalMousePosition() - cardUI.PivotOffset;
		}
		else if (@event.IsActionPressed("right_mouse"))
		{
			//InputEvent cancel = @event;
			EmitSignal(CardState.SignalName.TransitionRequested, this.state.ToString(), State.Base.ToString());
		}
		else if (minimumDragTimeElapsed && (@event.IsActionReleased("left_mouse") || @event.IsActionPressed("left_mouse")))
		{
			//InputEvent confirm = @event;
			GetViewport().SetInputAsHandled();
			EmitSignal(CardState.SignalName.TransitionRequested, this.state.ToString(), State.Released.ToString());
		}
    }
}
