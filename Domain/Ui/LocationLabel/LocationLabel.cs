using Godot;
using Pokemon.Domain.Ui.UiInfoManager;

namespace Pokemon.Domain.Ui.LocationLabel;

public partial class LocationLabel : Label
{
	# region ---- nodes --------------------------------------------------------

	private UiInfoManagerScene UiInfoManager =>
		GetNode<UiInfoManagerScene>(path:"/root/UiInfoManager");

	# endregion

	# region ---- built-in methods ---------------------------------------------

	public override void _Ready()
	{
		UiInfoManager.LocationNameChanged += OnLocationNameChanged;
	}

	# endregion

	# region ---- signals ------------------------------------------------------

	private void OnLocationNameChanged(string locationName) =>
		Text = locationName;

	# endregion
}
