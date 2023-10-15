using System;

namespace Pokemon.Domain.Pokemon.Stats;

public class Stat
{
    # region ---- constants ----------------------------------------------------

    private const byte BaseMultiplier = 2;
    private const byte Constant = 5;
    private const float Percent = 0.01f;

    # endregion

    # region ---- properties ---------------------------------------------------

    public ushort Value { get; private set; } = 1;
    public ushort BaseValue { get; private set; }
    public ushort OriginalValue { get; private set; } = 1;
    public Ev Ev { get; private set; } = 0;
    public Iv Iv { get; private set; } = new();

    # endregion

    # region ---- constructors -------------------------------------------------

    public Stat(ushort baseValue, byte level = 1)
    {
        BaseValue = baseValue;
        Update(level);
    }

    # endregion

    # region ---- update stat --------------------------------------------------

    public void Update(byte level = 1, float nature = 1f)
    {
        var result = Percent
                     * (BaseMultiplier * BaseValue + Iv + Ev.Coefficient)
                     * level;

        result += level + Constant;

        result *= nature;

        OriginalValue = (ushort) Math.Floor(result);
    }

    # endregion

    # region ---- modifiers ----------------------------------------------------

    public void Buff(float percent)
    {
        if (percent < 0) { return; }

        Value += (ushort) Math.Floor(OriginalValue * percent);
    }

    public void Debuff(float percent)
    {
        if (percent < 0) { return; }

        Value -= (ushort) Math.Floor(OriginalValue * percent);
    }

    public void Reset() => Value = OriginalValue;

    # endregion

    # region ---- evs / iv -----------------------------------------------------

    public void AddEv(byte value, byte level = 1)
    {
        Ev.Add(value);
        Update(level);
    }

    # endregion

    # region ---- implicit operator --------------------------------------------

    public static implicit operator ushort(Stat stat) => stat.Value;
    public static implicit operator Stat(ushort value) => new(value);

    # endregion

    # region ---- to string ----------------------------------------------------

    public override string ToString() => Value.ToString();

    # endregion
}
