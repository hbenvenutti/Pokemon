using Godot;
using Pokemon.Domain.Map.Interfaces;
using Pokemon.Domain.Ui.UiInfoManager;

namespace Pokemon.Domain.Map.Locations.Components.LocationPerimeter;

public partial class LocationPerimeterScene : Area2D
{
	# region ---- nodes --------------------------------------------------------

	private UiInfoManagerScene UiManagerScene =>
		GetNode<UiInfoManagerScene>(path: "/root/UiInfoManager");

	private ILocation Location => GetParent<ILocation>();

	# endregion

	# region ---- built-in methods ----------------------------------------------

	public override void _Ready() {	}

	# endregion

	# region ---- signals ------------------------------------------------------

	private void OnBodyEntered(Node _) =>
		UiManagerScene.LocationName = Location.LocationName;

	# endregion
}
