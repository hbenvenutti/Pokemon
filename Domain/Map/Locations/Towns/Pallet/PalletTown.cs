using Godot;
using Pokemon.Domain.Map.Interfaces;

namespace Pokemon.Domain.Map.Locations.Towns.Pallet;

public partial class PalletTown : Node2D, ILocation
{
	# region ---- properties ---------------------------------------------------

	public string LocationName => "Pallet Town";

	# endregion

	# region ---- built-in methods ---------------------------------------------

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	# endregion
}
