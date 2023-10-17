using Godot;
using Pokemon.Domain.Map.Interfaces;
using Pokemon.Scenes.Ui;

namespace Pokemon.Domain.Map.Locations.Components.LocationPerimeter;

public partial class LocationPerimeterScene : Area2D
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
