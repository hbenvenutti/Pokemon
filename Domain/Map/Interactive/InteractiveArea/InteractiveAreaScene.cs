using Godot;
using Pokemon.Domain.Map.Interactive.InteractionManager;

namespace Pokemon.Domain.Map.Interactive.InteractiveArea;

public partial class InteractiveAreaScene : Area2D
{
    # region ---- properties ---------------------------------------------------

    [ExportGroup(name: "C#")]
    [Export] public string ActionName { get; set; } = "interact";

    private InteractionManagerScene InteractionManager =>
        GetNode<InteractionManagerScene>(path:"/root/InteractionManager");

    public Marker2D LabelPosition;

    public Callable Interact { get; set; }

    # endregion

    # region ---- built-in methods ---------------------------------------------

    public override void _Ready()
    {
        LabelPosition = GetNode<Marker2D>(path: "LabelPosition");
    }

    # endregion

    # region ---- signals ------------------------------------------------------

    private void OnAreaEntered(Area2D _) =>
        InteractionManager.RegisterArea(this);

    private void OnAreaExited(Area2D _) =>
        InteractionManager.UnregisterArea(this);

    # endregion
}
