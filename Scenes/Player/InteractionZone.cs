using Godot;

namespace Pokemon.Scenes.Player;

public partial class InteractionZone : Marker2D
{
	# region ---- nodes --------------------------------------------------------

	private PlayerScene Player => GetParent<PlayerScene>();

	# endregion

	# region ---- built-in methods ---------------------------------------------

	public override void _Process(double delta)
	{
		HandlePlayerDirection();
	}

	# endregion

	# region ---- behavior -----------------------------------------------------

	private void HandlePlayerDirection()
	{
		Vector2 direction = Player.Direction;

		switch (direction)
		{
			case { Y: 1 }:
				Position = new Vector2(x: 0, y: 16);
				RotationDegrees = 0;
				break;

			case { X: 1 }:
				Position = new Vector2(x: 16, y: 0);
				RotationDegrees = 90;
				break;

			case { Y: -1 }:
				Position = new Vector2(x: 0, y: -16);
				RotationDegrees = 0;
				break;

			case { X: -1 }:
				Position = new Vector2(x: -16, y: 0);
				RotationDegrees = 90;
				break;
		}

	}

	# endregion
}
