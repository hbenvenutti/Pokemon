using System;
using System.Threading.Tasks;
using Godot;
using  Pokemon.Domain.Player.Scenes;

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

    public async void MoveAsync(
        PlayerScene player,
        double delta
    )
    {
        await BlockDiagonalMovementAsync();
        player.MoveAndCollide(motion: value * player.Speed * (float) delta);
    }

    # endregion

    # region ---- private methods ----------------------------------------------

    private async Task BlockDiagonalMovementAsync() => await Task.Run(() =>
    {
        if (!IsDiagonalEqual()) { return; }

        value = Vector2.Zero;
    });

    private bool IsDiagonalEqual() =>
        (Math.Abs(Math.Abs(value.X) - Math.Abs(value.Y)) < Tolerance);

    /* formula: | |x| - |y| | < tolerance
     * To avoid precision loss. x == y.
     */

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
