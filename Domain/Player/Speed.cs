using Godot;

namespace Pokemon.Domain.Player;

public struct Speed
{
    # region ---- properties ---------------------------------------------------

    private const ushort SpeedBoost = 2;
    private ushort _baseSpeed;

    public ushort Value { get; private set; }

    # endregion

    # region ---- modifiers ----------------------------------------------------

    public void SpeedUp(ushort amount)
    {
        Value *= amount;
        GD.Print(what: $"Speed boost of {amount}x");
    }

    public void SpeedDown(ushort amount) => Value /= amount;

    public void ResetSpeed()
    {
        Value = _baseSpeed;
        GD.Print(what: $"Speed reset back to {_baseSpeed}");
    }

    # endregion

    # region ---- behaviors ----------------------------------------------------

    public void HandleTurbo()
    {
        if (Input.IsActionJustPressed("ui_speed_up"))
        {
            SpeedUp(amount: SpeedBoost);
        }

        if (Input.IsActionJustReleased("ui_speed_up")) { ResetSpeed(); }
    }

    # endregion

    # region ---- implicit operators -------------------------------------------

    public static implicit operator ushort(Speed speed) => speed.Value;

    public static implicit operator uint(Speed speed) => speed.Value;

    public static implicit operator Speed(ushort value) => new()
    {
        _baseSpeed = value,
        Value = value
    };

    # endregion

    # region ---- to string ----------------------------------------------------

    public override string ToString() => Value.ToString();

    # endregion
}
