using Godot;

namespace Pokemon.Domain.Player;

public class Speed
{
    # region ---- properties ---------------------------------------------------

    private const ushort SpeedBoost = 2;
    private ushort baseSpeed = 50;
    private ushort value;

    # endregion

    # region ---- constructors -------------------------------------------------

    public Speed()
    {
        value = baseSpeed;
    }

    # endregion

    # region ---- modifiers ----------------------------------------------------

    public void SpeedUp(ushort amount) => value *= amount;

    public void SpeedDown(ushort amount) => value /= amount;

    public void ResetSpeed() => value = baseSpeed;

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

    public static implicit operator ushort(Speed speed) => speed.value;

    public static implicit operator uint(Speed speed) => speed.value;

    public static implicit operator Speed(ushort value) => new()
    {
        baseSpeed = value,
        value = value
    };

    # endregion

    # region ---- to string ----------------------------------------------------

    public override string ToString() => value.ToString();

    # endregion
}
