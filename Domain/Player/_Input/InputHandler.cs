using System.Threading.Tasks;
using Godot;
using Pokemon.Domain.Player.Scenes;
using Pokemon.Domain.Player.Structs;

namespace Pokemon.Domain.Player._Input;

public class InputHandler
{
    private readonly PlayerScene player;

    public InputHandler(PlayerScene player)
    {
        this.player = player;
    }

    public async void HandleInput()
    {
        if (Input.IsActionJustPressed(InputActions.Run))
        {
            Run();
        }

        if (Input.IsActionJustReleased(InputActions.Run))
        {
            StopRunning();
        }

        player.Direction = await Move();
    }


    # region ---- commands -----------------------------------------------------

    private void Run() => player.Speed.RunAsync();
    private void StopRunning() => player.Speed.StopRunningAsync();

    private static async Task<Vector2> Move() => await Task.Run(() =>
        new Vector2
        {
            X = Input.GetActionStrength(InputActions.MoveRight) -
                Input.GetActionStrength(InputActions.MoveLeft),

            Y = Input.GetActionStrength(InputActions.MoveDown) -
                Input.GetActionStrength(InputActions.MoveUp)
        }.Normalized()
    );

    # endregion
}
