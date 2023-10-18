using System.Collections.Generic;
using Godot;
using Pokemon.Domain.Player.Structs;

namespace Pokemon.Domain.Map.Interactive.InteractionManager;

public partial class InteractionManagerScene : Node2D
{
	# region ---- properties ---------------------------------------------------

	private const string BaseText = "?";

	private readonly IList<InteractiveArea.InteractiveArea> activeAreas =
		new List<InteractiveArea.InteractiveArea>();

	[ExportGroup(name: "C#")]
	[Export] private bool canInteract = true;

	# endregion

	# region ---- nodes --------------------------------------------------------

	private Label label;

	# endregion

	# region ---- built-in methods ---------------------------------------------

	public override void _Ready()
	{
		label = GetNode<Label>(path: "Label");

		label.Text = BaseText;
	}

	public override void _Process(double delta)
	{

		if (activeAreas.Count == 0 || !canInteract)
		{
			label.Hide();
			return;
		}

		ShowInteractionLabel();
	}

	public override void _Input(InputEvent @event)
	{
		if (!canInteract) { return; }

		if (!@event.IsActionPressed(InputActions.Interact)) { return; }

		if (activeAreas.Count == 0)
		{
			return;
		}

		canInteract = false;

		label.Hide();

		activeAreas[0].Interact.Call();

		canInteract = true;
	}

	# endregion

	private void ShowInteractionLabel()
	{
		var activeArea = activeAreas[0];

		var globalPosition = activeArea.LabelPosition.GlobalPosition;

		globalPosition.X -= label.Size.X / 2;

		label.GlobalPosition = globalPosition;

		label.Show();
	}

	# region ---- observers ----------------------------------------------------

	public void RegisterArea(InteractiveArea.InteractiveArea area)
	{
		activeAreas.Add(area);
	}

	public void UnregisterArea(InteractiveArea.InteractiveArea area)
	{
		activeAreas.Remove(area);
	}

	# endregion
}
