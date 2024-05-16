using TerminalMenu.Logic;

namespace TerminalMenu.Scenes;

public class CounterScene
{
    private List<Option> SceneOptions { get; set; }
    private Menu SceneMenu { get; set; }
    private int Count { get; set; } = 0;

    public CounterScene()
    {
        SceneOptions =
        [
            new() { Message = "Increment", Execute = () => Increment() },
            new() { Message = "Back to Main Menu", Execute = () => OpenMainScene() }
        ];

        SceneMenu = new()
        {
            PreMenuText = $"Count: {Count}\n",
            Options = SceneOptions,
            Alignment = Orientation.Vertical
        };
    }

    public void DrawScene()
    {
        SceneMenu.PreMenuText = $"Count: {Count}\n";
        SceneMenu.DrawMenu();
    }

    private void Increment()
    {
        Count++;
        DrawScene();
    }

    private void OpenMainScene()
    {
        MainScene mainScene = new();
        mainScene.DrawScene();
    }
}
