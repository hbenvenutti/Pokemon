namespace Pokemon.Domain.Pokemon.Attributes;

public readonly struct Height
{
    # region ---- properties ---------------------------------------------------

    private readonly float value;
    public float Inches => value * 39.37f;
    public string FeetAndInches => $"{Inches / 12}Ft {Inches % 12}";

    # endregion

    # region ---- constructors -------------------------------------------------

    public Height(float value) => this.value = value;

    # endregion

    # region ---- implicit operators -------------------------------------------

    public static implicit operator float(Height height) => height.value;
    public static implicit operator Height(float value) => new(value);

    # endregion

    # region ---- to string ----------------------------------------------------

    public string ToString(bool inches = false) => inches
        ? $"{Inches / 12}Ft {Inches % 12}"
        : $"{value}m";

    # endregion
}
