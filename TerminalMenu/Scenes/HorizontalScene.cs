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
            new() { Message = "First!", Execute = () => ChangeSelected("First option selected!") },
            new() { Message = "Second!", Execute = () => ChangeSelected("Second option selected!") },
            new() { Message = "Third!", Execute = () => ChangeSelected("Third option selected!") },
            new() { Message = "Back to Main Menu", Execute = () => { _ = new MainScene(); } }
        ];

        SceneMenu = new()
        {
            Options = SceneOptions,
            Alignment = Align.Horizontally,
            PreMenuText = "~ Horizontal Menu Demo ~\n",
            PostMenuText = "\n- Here use the LEFT and RIGHT arrow keys to navigate\n"
        };

        SceneMenu.DrawMenu();
    }

    private void ChangeSelected(string selected)
    {
        SceneMenu.PostMenuText = $"\n- Here use the LEFT and RIGHT arrow keys to navigate\n\n|>> {selected}";
    }
}
