using System;
using Godot;

namespace Pokemon.Domain.Pokemon.Stats;

public struct Hp
{
    # region ---- constants ----------------------------------------------------

    private const ushort BaseMultiplier = 2;
    private const ushort Constant = 10;
    private const float Percent = 0.01f;

    # endregion-----------------------------------------------------------------

    # region ---- properties ---------------------------------------------------
    public ushort Value { get; private set; } = 1;
    public ushort MaxValue { get; private set; } = 1;
    public ushort BaseValue { get; private set; } = 1;

    public Ev Ev { get; private set; } = 0;
    public Iv Iv { get; private set; } = new ();

    public bool IsDead => Value == 0;

    # endregion-----------------------------------------------------------------

    # region ---- constructors -------------------------------------------------

    public Hp(ushort value)
    {
        BaseValue = value;
        UpdateMaxValue();
        Value = MaxValue;
    }

    # endregion-----------------------------------------------------------------

    # region ---- update hp ----------------------------------------------------

    private void UpdateMaxValue(ushort level = 1)
    {
    /*
     ?? HP formula:
     ??   floor(0.01 x (2 x Base + IV + floor(0.25 x EV)) x Level) + Level + 10
    */
        var result = Percent
                     * (BaseMultiplier * BaseValue + Iv + Ev.Coefficient)
                     * level;

        result += level + Constant;

        MaxValue = (ushort) Math.Floor(result);
    }

    # endregion ----------------------------------------------------------------

    # region ---- evs / iv -----------------------------------------------------

    public void AddEv(byte value)
    {
        Ev.Add(value);

        UpdateMaxValue();

        GD.Print(what: $"EVs: {Ev}");
    }

    # endregion ----------------------------------------------------------------

    # region ---- damage -------------------------------------------------------

    public void TakeDamage(ushort amount)
    {
        GD.Print(what: $"Took {amount} damage");

        var result = Value - amount;

        if (result < 0)
        {
            Value = 0;
            GD.Print(what: "Pokemon fainted");
            return;
        }

        Value = (ushort) result;
    }

    # endregion ----------------------------------------------------------------

    # region ---- healing ------------------------------------------------------

    public void Heal(ushort amount)
    {
        if (IsDead) return;

        GD.Print(what: $"Healed {amount} hp");

        var result = Value + amount;

        if (result > MaxValue)
        {
            Value = MaxValue;
            return;
        }

        Value = (ushort) result;
    }

    public void HealPercent(ushort percent = 100)
    {
        if (IsDead) return;

        GD.Print(what: $"Healed {percent}% hp");

        var result = Value * (percent/100);

        if (result > MaxValue)
        {
            Value = MaxValue;
            return;
        }

        Value *= (ushort)(result);
    }

    # endregion-----------------------------------------------------------------

    # region ---- revive -------------------------------------------------------
    public void Revive(ushort percent = 0)
    {
        if (!IsDead) return;

        Value = 1;

        if (percent != 0) HealPercent(percent);

        GD.Print(what: "Pokemon revived");
    }

    # endregion-----------------------------------------------------------------

    # region ---- operators ----------------------------------------------------

    public static implicit operator ushort(Hp hp) => hp.Value;
    public static implicit operator Hp(ushort value) => new(value);

    # endregion-----------------------------------------------------------------

    # region ---- to string ----------------------------------------------------

    public override string ToString() => Value.ToString();

    # endregion-----------------------------------------------------------------
}
