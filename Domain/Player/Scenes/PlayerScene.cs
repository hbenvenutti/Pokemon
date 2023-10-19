using Godot;
using Pokemon.Domain.Player._Input;

namespace Pokemon.Domain.Player.Scenes;

public partial class PlayerScene : CharacterBody2D
{
	# region ---- properties ---------------------------------------------------

	public Speed Speed { get; } = new();
	public Direction Direction { get; set; } = Vector2.Zero;

	private InputHandler inputHandler = null!;

	# endregion

	# region ---- onready ------------------------------------------------------

	public override void _Ready()
	{
		inputHandler = new InputHandler(player: this);
	}

	# endregion

	# region ---- fisics process -----------------------------------------------

	public override void _PhysicsProcess(double delta)
	{
		inputHandler.HandleInput();
		Direction.MoveAsync(this, delta);
	}

	# endregion
}
