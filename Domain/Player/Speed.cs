using System.Threading.Tasks;
using Godot;
using Pokemon.Domain.Player.Structs;

namespace Pokemon.Domain.Player;

public class Speed
{
    # region ---- properties ---------------------------------------------------

    private const byte SpeedBoost = 2;
    private readonly byte baseSpeed = 50;
    private byte value;
    public bool IsBoosted => value > baseSpeed;

    # endregion

    # region ---- constructors -------------------------------------------------

    public Speed()
    {
        value = baseSpeed;
    }

    private Speed(byte value)
    {
        baseSpeed = value;
        this.value = value;
    }

    # endregion

    # region ---- modifiers ----------------------------------------------------

    private void SpeedUp(byte amount) => value *= amount;

    public void SpeedDown(byte amount) => value /= amount;

    private void ResetSpeed() => value = baseSpeed;

    # endregion

    # region ---- behaviors ----------------------------------------------------

    public async void HandleTurboAsync() => await Task.Run(() =>
    {
        if (Input.IsActionJustPressed(InputActions.SpeedUp))
        {
            SpeedUp(amount: SpeedBoost);
        }

        if (Input.IsActionJustReleased(InputActions.SpeedUp))
        {
            ResetSpeed();
        }
    });

    # endregion

    # region ---- implicit operators -------------------------------------------

    public static implicit operator ushort(Speed speed) => speed.value;

    public static implicit operator uint(Speed speed) => speed.value;

    public static implicit operator byte(Speed speed) => speed.value;

    public static implicit operator Speed(byte value) => new(value);

    # endregion

    # region ---- to string ----------------------------------------------------

    public override string ToString() => value.ToString();

    # endregion
}
