using Godot;
using Pokemon.Domain.Player.Structs;

namespace Pokemon.Domain.Player.Scenes.Sprite;

public partial class PlayerSpriteScene : AnimatedSprite2D
{
	# region ---- nodes --------------------------------------------------------

	private PlayerScene player;

	# endregion

	# region ---- built-in methods ---------------------------------------------

	public override void _Ready()
	{
		player = GetParent<PlayerScene>();
	}

	public override void _Process(double delta)
	{
		HandleAnimation();
	}

	# endregion

	# region ---- behaviors ----------------------------------------------------

	private void HandleAnimation()
	{
		if (player.Direction == Vector2.Zero)
		{
			if (!IsPlaying()) { return; }

			Stop();

			return;
		}

		Animation = (Vector2)player.Direction switch
		{
			{ Y: >= 1 } => PlayerAnimations.WalkDown,
			{ Y: <= -1 } => PlayerAnimations.WalkUp,
			{ X: >= 1 } => PlayerAnimations.WalkRight,
			{ X: <= -1 } => PlayerAnimations.WalkLeft,
			_ => Animation
		};

		if (IsPlaying()) { return; }

		Frame = 1;

		Play();
	}

	# endregion
}
