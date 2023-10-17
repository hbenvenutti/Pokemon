using Godot;
using Pokemon.Scenes.Locations.Interfaces;

namespace Pokemon.Scenes.Locations.Towns.Pallet;

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
