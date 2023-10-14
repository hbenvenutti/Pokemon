using Godot;

namespace Pokemon.Domain.Player;

public class Speed
{
    # region ---- properties ---------------------------------------------------

    private const ushort SpeedBoost = 2;
    private ushort baseSpeed = 50;

    private ushort Value { get; set; }

    # endregion

    # region ---- constructors -------------------------------------------------

    public Speed()
    {
        Value = baseSpeed;
    }

    # endregion

    # region ---- modifiers ----------------------------------------------------

    public void SpeedUp(ushort amount)
    {
        Value *= amount;
        GD.Print(what: Value);
        GD.Print(what: $"Speed boost of {amount}x");
    }

    public void SpeedDown(ushort amount) => Value /= amount;

    public void ResetSpeed()
    {
        Value = baseSpeed;

        GD.Print(what: $"Speed reset back to {baseSpeed}");
    }

    # endregion

    # region ---- behaviors ----------------------------------------------------

    public void HandleTurbo()
    {
        if (Input.IsActionJustPressed("ui_speed_up"))
        {
            SpeedUp(amount: SpeedBoost);
            GD.Print(what: "Turbo Activated");
        }

        if (Input.IsActionJustReleased("ui_speed_up"))
        {
            ResetSpeed();

            GD.Print(what: "Turbo Deactivated");
        }
    }

    # endregion

    # region ---- implicit operators -------------------------------------------

    public static implicit operator ushort(Speed speed) => speed.Value;

    public static implicit operator uint(Speed speed) => speed.Value;

    public static implicit operator Speed(ushort value) => new()
    {
        baseSpeed = value,
        Value = value
    };

    # endregion

    # region ---- to string ----------------------------------------------------

    public override string ToString() => Value.ToString();

    # endregion
}
