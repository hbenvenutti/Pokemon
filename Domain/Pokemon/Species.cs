using Pokemon.Domain.Pokemon.Attributes;
using Pokemon.Domain.Pokemon.Stats;
using Pokemon.Domain.Pokemon.Structs;

namespace Pokemon.Domain.Pokemon;

public abstract class Species
{
    # region ---- properties ---------------------------------------------------

    public string Id => $"#{NationalDexNumber}_{Name}_{Form}";

    public ushort NationalDexNumber { get; init; }
    public BaseStats BaseStats { get; init; }
    public string Name { get; init; }
    public string Form { get; init; }
    public EvYield EvYield { get; init; }
    public string PokedexEntry { get; init; }
    public bool IsBaby { get; init; }
    public Weight Weight { get; init; }
    public Height Height { get; init; }

    # endregion

    /* todo:
        evolutions
        egg group
        types
        abilities
        gender ratio
        growth rate
        base exp
        catch rate
        base happiness
        moves
        egg moves
        category
    */
}
