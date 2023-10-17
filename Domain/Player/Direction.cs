using System;
using System.Threading.Tasks;
using Godot;
using Pokemon.Domain.Player.Structs;
using Pokemon.Scenes.Player;

namespace Pokemon.Domain.Player;

public class Direction
{
    # region ---- properties ---------------------------------------------------

    private const double Tolerance = 1e-9;

    private Vector2 value;

    # endregion

    # region ---- constructors -------------------------------------------------

    private Direction(Vector2 value)
    {
        this.value = value;
    }

    # endregion

    # region ---- behaviors ----------------------------------------------------

    private async Task HandleDirectionAsync() => await Task.Run(() =>
    {
        value = new Vector2
        {
            X = Input.GetActionStrength(InputActions.MoveRight) -
                Input.GetActionStrength(InputActions.MoveLeft),

            Y = Input.GetActionStrength(InputActions.MoveDown) -
                Input.GetActionStrength(InputActions.MoveUp)
        }.Normalized();

        if (Math.Abs(Math.Abs(value.X) - Math.Abs(value.Y)) < Tolerance)
        {
            /* formula: | |x| - |y| | < tolerance
             *
             * The formula is used to avoid precision loss. x == y.
             *
             * This is to prevent the player from moving diagonally.
             */

            value = Vector2.Zero;
        }
    });

    public async void HandlePlayerMovementAsync(
        PlayerScene player,
        double delta
    )
    {
        await HandleDirectionAsync();
        player.MoveAndCollide(motion: value * player.Speed * (float) delta);
    }

    # endregion

    # region ---- implicit operators -------------------------------------------

    public static implicit operator Vector2(Direction direction) =>
        direction.value;

    public static implicit operator Direction(Vector2 value) => new(value);

    # endregion

    # region ---- to string ----------------------------------------------------

    public override string ToString() => $"({value.X}, {value.Y})";

    # endregion
}
