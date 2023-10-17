using Godot;
using Pokemon.Scenes.Ui;

namespace Pokemon.Scenes.Towns;

public partial class PalletTown : Node2D
{
	public const string TownName = "Pallet Town";

	private UiInfoManager uiInfoManager;

	# region ---- built-in methods ---------------------------------------------

	public override void _Ready()
	{
		uiInfoManager = GetNode<UiInfoManager>(path: "/root/UiInfoManager");

		uiInfoManager.LocationName = TownName;
	}

	public override void _Process(double delta)
	{
	}

	# endregion
}
