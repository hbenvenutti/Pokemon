using System.Collections.Generic;
using Godot;
using Pokemon.Scenes.Player;
using Pokemon.Scenes.Structs;

namespace Pokemon.Scenes.Misc.Interactions;

public partial class InteractionManager : Node2D
{
	# region ---- properties ---------------------------------------------------

	private const string BaseText = "?";

	private readonly IList<InteractionArea> activeAreas =
		new List<InteractionArea>();

	[ExportGroup(name: "C#")]
	[Export] private bool canInteract = true;

	# endregion

	# region ---- nodes --------------------------------------------------------

	public PlayerScene Player;
	private Label label;

	# endregion

	# region ---- built-in methods ---------------------------------------------

	public override void _Ready()
	{

		if (Player is null) GD.Print(what: $"Player is null");

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
		if (@event.IsActionPressed(InputActions.Interact) && canInteract)
		{
			if (activeAreas.Count == 0)
			{
				return;
			}

			canInteract = false;

			label.Hide();

			activeAreas[0].Interact.Call();

			canInteract = true;
		}
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

	public void RegisterArea(InteractionArea area)
	{
		activeAreas.Add(area);
	}

	public void UnregisterArea(InteractionArea area)
	{
		activeAreas.Remove(area);
	}

	# endregion
}
