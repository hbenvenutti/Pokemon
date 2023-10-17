using Godot;

namespace Pokemon.Scenes.Ui;

public partial class UiInfoManager : Control
{
	[ExportGroup(name: "C#")]
	[Export]
	public string LocationName { get; set; }

	# region ---- built-in methods ---------------------------------------------

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	# endregion
}
