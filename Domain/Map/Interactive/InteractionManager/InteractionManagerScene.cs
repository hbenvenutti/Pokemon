using System.Collections.Generic;
using Godot;
using Pokemon.Domain.Map.Interactive.InteractiveArea;
using Pokemon.Domain.Player.Structs;

namespace Pokemon.Domain.Map.Interactive.InteractionManager;

public partial class InteractionManagerScene : Node2D
{
	# region ---- properties ---------------------------------------------------

	private const string BaseText = "?";

	private readonly IList<InteractiveAreaScene> activeAreas =
		new List<InteractiveAreaScene>();

	[ExportGroup(name: "C#")]
	[Export] private bool canInteract = true;

	# endregion

	# region ---- nodes --------------------------------------------------------

	private Label Label => GetNode<Label>(path: "Label");

	# endregion

	# region ---- built-in methods ---------------------------------------------

	public override void _Ready()
	{
		Label.Text = BaseText;
	}

	public override void _Process(double delta)
	{

		if (activeAreas.Count == 0 || !canInteract)
		{
			Label.Hide();
			return;
		}

		ShowInteractionLabel();
	}

	public override void _Input(InputEvent @event)
	{
		if (!canInteract) { return; }

		if (!@event.IsActionPressed(InputActions.Interact)) { return; }

		if (activeAreas.Count == 0) { return; }

		canInteract = false;

		Label.Hide();

		activeAreas[0].Interact.Call();

		canInteract = true;
	}

	# endregion

	private void ShowInteractionLabel()
	{
		var activeArea = activeAreas[0];

		var globalPosition = activeArea.LabelPosition.GlobalPosition;

		globalPosition.X -= Label.Size.X / 2;

		Label.GlobalPosition = globalPosition;

		Label.Show();
	}

	# region ---- observers ----------------------------------------------------

	public void RegisterArea(InteractiveAreaScene area)
	{
		activeAreas.Add(area);
	}

	public void UnregisterArea(InteractiveAreaScene area)
	{
		activeAreas.Remove(area);
	}

	# endregion
}
