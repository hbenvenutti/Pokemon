using System;
using Godot;

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

    public void HandleDirection(bool verbose = false)
    {
        value = new Vector2
        {
            X = Input.GetActionStrength("ui_right") -
                Input.GetActionStrength("ui_left"),

            Y = Input.GetActionStrength("ui_down") -
                Input.GetActionStrength("ui_up")
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

        if (verbose)
        {
            GD.Print(what: $"Direction: {value}");
        }
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
