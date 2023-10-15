using System;

namespace Pokemon.Domain.Pokemon.Stats;

public struct Ev
{
    # region ---- properties ---------------------------------------------------

    public byte Value { get; private set; } = 0;
    public bool IsMax => Value == byte.MaxValue;
    public float Coefficient => (float) Math.Floor(Value / 4f);

    # endregion

    # region ---- constructors -------------------------------------------------

    public Ev(byte value)
    {
        Value = value;
    }

    # endregion

    # region ---- modifiers ----------------------------------------------------

    public void Add(byte value)
    {
        var result = (ushort) (Value + value);

        Value = (byte) (result > byte.MaxValue ? byte.MaxValue :  result);
    }

    # endregion

    # region ---- implicit operators -------------------------------------------

    public static implicit operator byte(Ev ev) => ev.Value;
    public static implicit operator Ev(byte value) => new(value);

    # endregion

    # region ---- to string ----------------------------------------------------

    public override string ToString() => Value.ToString();

    # endregion
}
