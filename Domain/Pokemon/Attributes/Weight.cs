namespace Pokemon.Domain.Pokemon.Attributes;

public struct Weight
{
    # region ---- properties ---------------------------------------------------

    public float Value { get; private set; }
    public float ValueInPounds => Value * 2.205f;
    public string Pounds => $"{ValueInPounds} Lbs";

    # endregion

    # region ---- constructors -------------------------------------------------

    public Weight(float value) => Value = value;

    # endregion

    # region ---- implicit operators -------------------------------------------

    public static implicit operator float(Weight weight) => weight.Value;
    public static implicit operator Weight(float value) => new(value);

    # endregion

    # region ---- to string ----------------------------------------------------

    public override string ToString() => $"{Value} Kg";

    # endregion
}
