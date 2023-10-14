using Pokemon.Domain.Pokemon.Enums;

namespace Pokemon.Domain.Pokemon.Stats;

public struct EvYield
{
    # region ---- properties ---------------------------------------------------

    private readonly byte value;
    private readonly StatEnum stat;

    # endregion

    # region ---- constructors -------------------------------------------------

    public EvYield(StatEnum stat, byte value = 1)
    {
        this.value = value;
        this.stat = stat;
    }

    # endregion

    # region ---- implicit operators -------------------------------------------

    public static implicit operator EvYield(StatEnum stat) => new(stat);
    public static implicit operator byte(EvYield evYield) => evYield.value;
    public static implicit operator StatEnum(EvYield evYield) => evYield.stat;

    # endregion
}
