using Godot;

namespace Pokemon.Domain.Pokemon;

public struct Hp
{
    // ? variables ---------------------------------------------------------- //

    public ushort Value { get; private set; } = 1;
    public ushort MaxValue { get; private set; } = 1;
    public ushort BaseValue { get; private set; } = 1;
    public bool IsDead => Value == 0;

    // ? constructors ------------------------------------------------------- //

    public Hp(ushort value)
    {
        BaseValue = value;
        UpdateMaxValue();
        Value = MaxValue;
    }

    // ? modifiers ---------------------------------------------------------- //

    private void UpdateMaxValue() => MaxValue = (ushort)(BaseValue * 2 + 110);

    // ? damage ------------------------------------------------------------- //

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

    // ? heal --------------------------------------------------------------- //

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

    // ? operators ---------------------------------------------------------- //

    public static implicit operator ushort(Hp hp) => hp.Value;

    public static implicit operator Hp(ushort value) => new(value);
}
