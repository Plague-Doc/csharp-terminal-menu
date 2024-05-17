namespace TerminalMenu.Logic;

public class Menu
{
    public required List<Option> Options { get; set; }
    public Align Alignment { get; set; } = Align.Vertically;
    public Action? PreMenuExecute { get; set; }
    public Action? PostMenuExecute { get; set; }
    public string? PreMenuText { get; set; }
    public string? PostMenuText { get; set; }
    public int Index { get; set; } = 0;

    public void DrawMenu()
    {
        do
        {
            Console.Clear();
            Console.CursorVisible = false;

            PreMenuExecute?.Invoke();
            if (!string.IsNullOrEmpty(PreMenuText)) { Console.WriteLine(PreMenuText); }

            if (Alignment == Align.Vertically) { DrawMenuVertical(); }
            else { DrawMenuHorizontal(); }

            PostMenuExecute?.Invoke();
            if (!string.IsNullOrEmpty(PostMenuText)) { Console.WriteLine(PostMenuText); }

        }
        while (GetUserInput().Key != ConsoleKey.Enter);

        Options[Index].Execute();

        DrawMenu();
    }

    public void ResetSelectPosition() { Index = 0; }

    private void DrawMenuVertical()
    {
        for (int i = 0; i < Options.Count; i++)
        {
            if (i == Index)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine($">> {Options[i].Message} <<");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"> {Options[i].Message} <");
            }
        }
    }

    private void DrawMenuHorizontal()
    {
        for (int i = 0; i < Options.Count; i++)
        {
            if (i != 0) { Console.Write("   "); }

            if (i == Index)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write($">| {Options[i].Message} | <");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"| {Options[i].Message} | ");
            }
        }

        Console.WriteLine();
    }

    private ConsoleKeyInfo GetUserInput()
    {
        ConsoleKeyInfo keyPressed;

        while (true)
        {
            keyPressed = Console.ReadKey(true);

            if (keyPressed.Key == ConsoleKey.Enter)
            {
                return keyPressed;
            }
            else if ((keyPressed.Key == ConsoleKey.UpArrow || keyPressed.Key == ConsoleKey.W) &&
                Alignment == Align.Vertically && Index > 0)
            {
                Index--;
                return keyPressed;
            }
            else if ((keyPressed.Key == ConsoleKey.DownArrow || keyPressed.Key == ConsoleKey.S) &&
                Alignment == Align.Vertically && Index < Options.Count - 1)
            {
                Index++;
                return keyPressed;
            }
            else if ((keyPressed.Key == ConsoleKey.LeftArrow || keyPressed.Key == ConsoleKey.A) &&
                Alignment == Align.Horizontally && Index > 0)
            {
                Index--;
                return keyPressed;
            }
            else if ((keyPressed.Key == ConsoleKey.RightArrow || keyPressed.Key == ConsoleKey.D) &&
                Alignment == Align.Horizontally && Index < Options.Count - 1)
            {
                Index++;
                return keyPressed;
            }
        }
    }
}

public class Option
{
    public required string Message { get; set; }
    public required Action Execute { get; set; }
}

public enum Align { Vertically, Horizontally }
