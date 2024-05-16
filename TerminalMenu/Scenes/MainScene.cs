using TerminalMenu.Logic;

namespace TerminalMenu.Scenes;

public class MainScene
{
    private List<Option> SceneOptions { get; set; }
    private Menu SceneMenu { get; set; }

    public MainScene()
    {
        SceneOptions =
        [
            new() { Message = "Counter", Execute = () => OpenCounterScene() },
            new() { Message = "Horizontal Menu", Execute = () => OpenHorizontalScene() },
            new() { Message = "Toggle Help", Execute = () => ToggleHelpMessage() },
            new() { Message = "Exit", Execute = () => { } },

        ];

        SceneMenu = new()
        {
            PreMenuText = "~ Terminal UI ~\n",
            PostMenuText = $"\n- Use the UP and DOWN arrow to navigate\n- Press ENTER to select an option",
            Options = SceneOptions,
            Alignment = Orientation.Vertical
        };
    }

    public void DrawScene()
    {
        SceneMenu.DrawMenu();
    }

    private void OpenCounterScene()
    {
        CounterScene counterScene = new();
        counterScene.DrawScene();
    }

    private void OpenHorizontalScene()
    {
        HorizontalScene horizontalScene = new();
        horizontalScene.DrawScene();
    }

    private void ToggleHelpMessage()
    {
        if (string.IsNullOrEmpty(SceneMenu.PostMenuText))
        {
            SceneMenu.PostMenuText = $"\n- Use the UP and DOWN arrow to navigate\n- Press ENTER to select an option";
        }
        else
        {
            SceneMenu.PostMenuText = "";
        }
        DrawScene();
    }
}
