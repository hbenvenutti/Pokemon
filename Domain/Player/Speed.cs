using Godot;

namespace Pokemon.Domain.Player;

public struct Speed
{
    // ? variables ---------------------------------------------------------- //
    private const ushort SpeedBoost = 2;

    private ushort _value;
    private ushort _baseSpeed;

    // ? modifiers ---------------------------------------------------------- //
    public void SpeedUp(ushort amount)
    {
        _value *= amount;
        GD.Print(what: $"Speed boost of {amount}x");
    }

    public void SpeedDown(ushort amount) => _value /= amount;

    public void ResetSpeed()
    {
        _value = _baseSpeed;
        GD.Print(what: $"Speed reset back to {_baseSpeed}");
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
    public static implicit operator ushort(Speed speed) => speed._value;

    public static implicit operator uint(Speed speed) => speed._value;

    public static implicit operator Speed(ushort value) => new()
    {
        _baseSpeed = value,
        _value = value
    };

    // ? overrides ---------------------------------------------------------- //

    public override string ToString() => _value.ToString();
}
