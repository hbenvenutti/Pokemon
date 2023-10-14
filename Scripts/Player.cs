using Godot;
using Pokemon.Domain.Player;

namespace Pokemon.Scripts;

public partial class Player : CharacterBody2D
{
	public Speed Speed = 50;

	private readonly Direction _direction = Vector2.Zero;

	public override void _PhysicsProcess(double delta)
	{
		Speed.HandleTurbo();
		_direction.HandleDirection();

		var movement = (Vector2) _direction * Speed * (float) delta;

		MoveAndCollide(movement);
	}
}
