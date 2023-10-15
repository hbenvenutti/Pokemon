using Godot;
using Pokemon.Domain.Player.Structs;

namespace Pokemon.Scenes.Player;

public partial class PlayerSceneSprite : AnimatedSprite2D
{
	private PlayerScene player;

	# region built-in methods --------------------------------------------------

	public override void _Ready()
	{
		player = GetParent<PlayerScene>();
	}

	public override void _Process(double delta)
	{
		HandleAnimation();
	}

	# endregion

	public void HandleAnimation()
	{
		if (player.Direction == Vector2.Zero)
		{
			Stop();

			return;
		}

		Animation = (Vector2) player.Direction switch
		{
			{ Y: >= 1 } => PlayerAnimations.WalkDown,
			{ Y: <= -1 } => PlayerAnimations.WalkUp,
			{ X: >= 1 } => PlayerAnimations.WalkRight,
			{ X: <= -1 } => PlayerAnimations.WalkLeft,
			_ => Animation
		};

		Play();
	}
}
