using TerminalMenu.Logic;

namespace TerminalMenu.Scenes;

public class HorizontalScene
{
    private List<Option> SceneOptions { get; set; }
    private Menu SceneMenu { get; set; }

    public HorizontalScene()
    {
        SceneOptions =
        [
            new() { Message = "First!", Execute = () => ChangeSelected("\n First option selected") },
            new() { Message = "Second!", Execute = () => ChangeSelected("\n Second option selected") },
            new() { Message = "Third!", Execute = () => ChangeSelected("\n Third option selected") },
            new() { Message = "Back to Main Menu", Execute = () => OpenMainScene() }
        ];

        SceneMenu = new()
        {
            PreMenuText = "Here use the LEFT and RIGHT arrow keys to navigate\n",
            Options = SceneOptions,
            Alignment = Orientation.Horizontal
        };
    }
    public void DrawScene()
    {
        SceneMenu.DrawMenu();
    }

    private void ChangeSelected(string selected)
    {
        SceneMenu.PostMenuText = selected;
        DrawScene();
    }

    private void OpenMainScene()
    {
        MainScene mainScene = new();
        mainScene.DrawScene();
    }
}
