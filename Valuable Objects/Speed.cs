using Godot;

namespace Pokemon.Valuable_Objects;

public struct Speed
{
    // ? variables ---------------------------------------------------------- //
    private const ushort SpeedBoost = 2;

    private ushort Value;
    private ushort BaseSpeed;

    // ? modifiers ---------------------------------------------------------- //
    public void SpeedUp(ushort amount)
    {
        Value *= amount;
        GD.Print(what: $"Speed boost of {amount}x");
    }

    public void SpeedDown(ushort amount) => Value /= amount;

    public void ResetSpeed()
    {
        Value = BaseSpeed;
        GD.Print(what: $"Speed reset back to {BaseSpeed}");
    }

    // ? behaviors ---------------------------------------------------------- //
    public void HandleTurbo()
    {
        if (Input.IsActionJustPressed("ui_speed_up"))
        {
            SpeedUp(amount: SpeedBoost);
        }

        if (Input.IsActionJustReleased("ui_speed_up")) { ResetSpeed(); }
    }

    // ? operators ---------------------------------------------------------- //
    public static implicit operator ushort(Speed speed) => speed.Value;

    public static implicit operator Speed(ushort value) => new()
    {
        BaseSpeed = value,
        Value = value
    };

    // ? overrides ---------------------------------------------------------- //
    public override string ToString() => Value.ToString();
}
