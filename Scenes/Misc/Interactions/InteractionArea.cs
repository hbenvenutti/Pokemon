using Godot;

namespace Pokemon.Scenes.Misc.Interactions;

public partial class InteractionArea : Area2D
{
    # region ---- properties ---------------------------------------------------

    [ExportGroup(name: "C#")]
    [Export] public string ActionName { get; set; } = "interact";

    private InteractionManager InteractionManager { get; set; }
    public Marker2D LabelPosition;

    public Callable Interact { get; set; }

    # endregion

    # region ---- built-in methods ---------------------------------------------

    public override void _Ready()
    {
        InteractionManager =
            GetNode<InteractionManager>(path:"/root/InteractionManager");

        LabelPosition = GetNode<Marker2D>(path: "LabelPosition");

        if (LabelPosition is null) GD.Print("Label Position is null");
    }

    # endregion

    # region ---- signals ------------------------------------------------------

    private void OnAreaEntered(Area2D body)
    {
        GD.Print(what: $"OnAreaEntered");
        InteractionManager.RegisterArea(this);
    }

    private void OnAreaExited(Area2D body)
    {
        GD.Print(what: $"OnBodyExited");
        InteractionManager.UnregisterArea(this);
    }

    # endregion
}
