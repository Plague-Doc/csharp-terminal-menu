using TerminalMenu.Logic;

namespace TerminalMenu.Scenes;

public static class CounterStaticScene
{
    private static List<Option> SceneOptions { get; set; }
    private static Menu SceneMenu { get; set; }
    private static int Count { get; set; } = 0;

    static CounterStaticScene()
    {
        SceneOptions =
        [
            new() { Message = "Increment", Execute = () => Increment() },
            new() { Message = "Reset", Execute = () => ResetCount() },
            new() { Message = "Back to Main Menu", Execute = () => { _ = new MainScene(); } }
        ];

        SceneMenu = new()
        {
            Options = SceneOptions,
            PreMenuText = $"Count: {Count}\n",
            PostMenuText = "\nWhen made static, the state (in this case the Count),\nstays even when navigating between different Scenes."
        };
    }

    public static void Draw()
    {
        SceneMenu.ResetSelectPosition();
        SceneMenu.DrawMenu();
    }

    private static void Increment()
    {
        Count++;
        SceneMenu.PreMenuText = $"Count: {Count}\n";
    }

    private static void ResetCount()
    {
        Count = 0;
        SceneMenu.PreMenuText = $"Count: {Count}\n";
    }
}
