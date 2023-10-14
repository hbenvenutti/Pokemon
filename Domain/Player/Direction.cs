using Godot;

namespace Pokemon.Domain.Player;

public class Direction
{
    // ---- properties ------------------------------------------------------ //

    private Vector2 _value;

    // ---- behaviors ------------------------------------------------------- //

    public void HandleDirection(bool verbose = false)
    {
        _value = new Vector2
        {
            X = Input.GetActionStrength("ui_right") -
                Input.GetActionStrength("ui_left"),

            Y = Input.GetActionStrength("ui_down") -
                Input.GetActionStrength("ui_up")
        }.Normalized();

        if (verbose)
            GD.Print(what: $"Direction: {_value}");
    }

    // ---- operators ------------------------------------------------------- //

    public static implicit operator Vector2(Direction direction) =>
        direction._value;

    public static implicit operator Direction(Vector2 value) => new()
    {
        _value = value
    };

    // ---- overrides ------------------------------------------------------- //

    public override string ToString() => $"({_value.X}, {_value.Y})";
}
