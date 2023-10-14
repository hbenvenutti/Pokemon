using Pokemon.Domain.Pokemon.Enums;

namespace Pokemon.Domain.Pokemon.Stats;

public struct EvYield
{
    # region ---- properties ---------------------------------------------------

    public byte Value { get; }
    public Stat Stat { get; }

    # endregion

    # region ---- constructors -------------------------------------------------

    public EvYield(byte value, Stat stat)
    {
        Value = value;
        Stat = stat;
    }

    # endregion
}
