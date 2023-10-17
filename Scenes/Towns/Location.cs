using Godot;
using Pokemon.Scenes.Ui;

namespace Pokemon.Scenes.Towns;

public partial class Location : Area2D
{
	# region ---- nodes ---------------------------------------------------------

	private UiInfoManager UiManager => GetNode<UiInfoManager>(path: "/root/UiInfoManager");
	private PalletTown PalletTown => GetParent<PalletTown>();

	# endregion

	# region ---- built-in methods ----------------------------------------------

	public override void _Ready()
	{
	}

	# endregion

	# region ---- signals -------------------------------------------------------

	private void OnBodyEntered(Node body)
	{
			UiManager.LocationName = PalletTown.TownName;
	}

	# endregion
}
