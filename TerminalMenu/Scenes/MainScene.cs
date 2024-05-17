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
            new() { Message = "Counter", Execute = () => { _ = new CounterScene(); } },
            new() { Message = "Static Counter", Execute = () => CounterStaticScene.Draw() },
            new() { Message = "Horizontal Menu", Execute = () => { _ = new HorizontalScene(); } },
            new() { Message = "Toggle Help", Execute = () => ToggleHelpMessage() },
            new() { Message = "Exit", Execute = () => Environment.Exit(0) }

        ];

        SceneMenu = new()
        {
            Options = SceneOptions,
            PreMenuText = "~ Terminal UI ~\n",
            PostMenuText = $"\n- Use the UP and DOWN arrow to navigate\n- Press ENTER to select an option"
        };

        SceneMenu.DrawMenu();
    }

    private void ToggleHelpMessage()
    {
        SceneMenu.PostMenuText = string.IsNullOrEmpty(SceneMenu.PostMenuText) ? $"\n- Use the UP and DOWN arrow to navigate\n- Press ENTER to select an option" : "";
    }
}
