using System;

namespace Pokemon.Domain.Pokemon.Stats;

public struct Iv
{
    # region ---- properties ---------------------------------------------------

    private const byte Max = 31;

    public byte Value { get; private set; } = 0;
    public bool IsMax => Value == Max;

    # endregion

    # region ---- constructors -------------------------------------------------

    public Iv()
    {
        var random = new Random();

        Value = (byte) random.NextInt64(maxValue: Max);
    }

    public Iv(byte value)
    {
        Value = value > Max ? Max : value;
    }

    # endregion ----------------------------------------------------------------

    # region ---- modifiers ----------------------------------------------------

    public void Add(byte value)
    {
        var result = (ushort) (Value + value);

        Value = (byte) (result > Max ? Max : result);
    }

    # endregion ----------------------------------------------------------------

    # region ---- operators ----------------------------------------------------

    public static implicit operator byte(Iv iv) => iv.Value;
    public static implicit operator Iv(byte value) => new(value);

    # endregion ----------------------------------------------------------------
}
