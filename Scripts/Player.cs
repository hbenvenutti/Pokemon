using Godot;
using Pokemon.Valuable_Objects;

namespace Pokemon.Scripts;

public partial class Player : CharacterBody2D
{
	// [Export]
	public Speed Speed = 50;

	private const ushort SpeedBoost = 2;

	public override void _PhysicsProcess(double delta)
	{
		Speed.HandleTurbo();

		var direction = new Vector2
			{
				X = Input.GetActionStrength("ui_right") -
				    Input.GetActionStrength("ui_left"),

				Y = Input.GetActionStrength("ui_down") -
				    Input.GetActionStrength("ui_up")
			}
			.Normalized();

		var movement = direction * Speed * (float) delta;

		MoveAndCollide(movement);
	}
}
