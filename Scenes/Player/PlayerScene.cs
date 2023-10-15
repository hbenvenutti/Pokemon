using Godot;
using Pokemon.Domain.Player;

namespace Pokemon.Scenes.Player;

public partial class PlayerScene : CharacterBody2D
{
	# region ---- properties ---------------------------------------------------

	public Speed Speed { get; } = new();
	public Direction Direction { get; } = Vector2.Zero;

	# endregion

	# region ---- onready ------------------------------------------------------

	public override void _Ready()
	{
	}

	# endregion

	# region ---- fisics process -----------------------------------------------

	public override void _PhysicsProcess(double delta)
	{
		Speed.HandleTurbo();
		Direction.HandleDirection();

		var movement = (Vector2) Direction * Speed * (float) delta;
		MoveAndCollide(movement);
	}

	# endregion
}
