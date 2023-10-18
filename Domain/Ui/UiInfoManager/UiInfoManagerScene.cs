using Godot;

namespace Pokemon.Domain.Ui.UiInfoManager;

public partial class UiInfoManagerScene : Control
{
	private string locationName;
	
	[ExportGroup(name: "C#")]
	[Export]
	public string LocationName
	{
		get => locationName;
		set
		{
			locationName = value;
			EmitSignal(nameof(LocationNameChangedEventHandler), value);
		}
	}

	# region ---- signals ------------------------------------------------------

	[Signal]
	public delegate void LocationNameChangedEventHandler(string locationName);

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
