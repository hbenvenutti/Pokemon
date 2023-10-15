namespace Pokemon.Domain.Pokemon.Structs;

public readonly struct BaseStats
{
    # region ---- properties ---------------------------------------------------

    public ushort Hp { get; init; }
    public ushort Attack { get; init; }
    public ushort Defense { get; init; }
    public ushort SpecialAttack { get; init; }
    public ushort SpecialDefense { get; init; }
    public ushort Speed { get; init; }

    # endregion

    # region ---- constructors -------------------------------------------------

    public BaseStats(
        ushort hp,
        ushort attack,
        ushort defense,
        ushort specialAttack,
        ushort specialDefense,
        ushort speed
    )
    {
        Hp = hp;
        Attack = attack;
        Defense = defense;
        SpecialAttack = specialAttack;
        SpecialDefense = specialDefense;
        Speed = speed;
    }

    # endregion ----------------------------------------------------------------
}
