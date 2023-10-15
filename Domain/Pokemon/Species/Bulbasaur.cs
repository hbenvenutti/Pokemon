#region usings

using Pokemon.Domain.Pokemon.Attributes;
using Pokemon.Domain.Pokemon.Enums;
using Pokemon.Domain.Pokemon.Species.Interfaces;
using Pokemon.Domain.Pokemon.Stats;
using Pokemon.Domain.Pokemon.Structs;

#endregion

namespace Pokemon.Domain.Pokemon.Species;

public class Bulbasaur : ISpecies
{
    public ushort NationalDexNumber { get; init; } = 1;
    public string Name { get; init; } = "Bulbasaur";
    public string Form { get; init; } = Forms.Normal;

    public string PokedexEntry { get; init; } =
        "A strange seed was planted on its back at birth. " +
        "The plant sprouts and grows with this POKÉMON.";

    public bool IsBaby { get; init; } = false;

    public EvYield EvYield { get; init; } = StatEnum.SpecialAttack;
    public Weight Weight { get; init; } = 6.9f;
    public Height Height { get; init; } = 0.7f;
    public BaseStats BaseStats { get; init; } = new(
        hp: 45,
        attack: 49,
        defense: 49,
        specialAttack: 65,
        specialDefense: 65,
        speed: 45
    );
}
