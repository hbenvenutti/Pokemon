using Godot;

namespace Pokemon.Domain.Pokemon;

public struct Hp
{
    // ---- properties ------------------------------------------------------ //

    private const ushort Multiplier = 2;
    private const ushort Constant = 110;

    public ushort Value { get; private set; } = 1;
    public ushort MaxValue { get; private set; } = 1;
    public ushort BaseValue { get; private set; } = 1;
    public Ev Ev { get; private set; } = 0;
    public bool IsDead => Value == 0;

    // todo: EVs
    // todo: IVs
    // todo: nature

    // ---- constructors ---------------------------------------------------- //

    public Hp(ushort value)
    {
        BaseValue = value;
        UpdateMaxValue();
        Value = MaxValue;
    }

    // ---- modifiers ------------------------------------------------------- //

    private void UpdateMaxValue() => MaxValue
        = (ushort)(BaseValue * Multiplier + Constant);

    public void AddEv(ushort value)
    {
        Ev.Add(value);

        UpdateMaxValue();

        GD.Print(what: $"EVs: {Ev}");
    }

    // ---- damage ---------------------------------------------------------- //

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

    // ---- healing --------------------------------------------------------- //

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

    public void Revive(ushort percent = 0)
    {
        if (!IsDead) return;

        Value = 1;

        if (percent != 0) HealPercent(percent);

        GD.Print(what: "Pokemon revived");
    }

    // ---- operators ------------------------------------------------------- //

    public static implicit operator ushort(Hp hp) => hp.Value;

    public static implicit operator Hp(ushort value) => new(value);

    // ---- overrides ------------------------------------------------------- //

    public override string ToString() => Value.ToString();
}
