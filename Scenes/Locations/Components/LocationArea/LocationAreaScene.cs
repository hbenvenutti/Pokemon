using Godot;
using Pokemon.Scenes.Locations.Interfaces;
using Pokemon.Scenes.Ui;

namespace Pokemon.Scenes.Locations.Components.LocationArea;

public partial class LocationAreaScene : Area2D
{
	# region ---- nodes --------------------------------------------------------

	private UiInfoManager UiManager =>
		GetNode<UiInfoManager>(path: "/root/UiInfoManager");

	private ILocation Location => GetParent<ILocation>();

	# endregion

	# region ---- built-in methods ----------------------------------------------

	public override void _Ready()
	{
	}

	# endregion

	# region ---- signals ------------------------------------------------------

	private void OnBodyEntered(Node _)
	{
		GD.Print("Entered Pallet Town");
		UiManager.LocationName = Location.LocationName;
	}

	# endregion
}
