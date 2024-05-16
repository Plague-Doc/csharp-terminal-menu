namespace TerminalMenu.Logic;

public class Menu
{
    public string? PreMenuText { get; set; }
    public string? PostMenuText { get; set; }
    public required List<Option> Options { get; set; }
    public required Orientation Alignment { get; set; }
    private int Index { get; set; } = 0;

    public void DrawMenu()
    {
        do
        {
            Console.Clear();

            if (!string.IsNullOrEmpty(PreMenuText)) { Console.WriteLine(PreMenuText); }

            if (Alignment == Orientation.Vertical) { DrawMenuVertical(); }
            else { DrawMenuHorizontal(); }

            if (!string.IsNullOrEmpty(PostMenuText)) { Console.WriteLine(PostMenuText); }

        }
        while (GetUserInput().Key != ConsoleKey.Enter);

        Options[Index].Execute();
    }

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
                Console.Write($">| {Options[i].Message}| <");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"| {Options[i].Message}| ");
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
                Alignment == Orientation.Vertical && Index > 0)
            {
                Index--;
                return keyPressed;
            }
            else if ((keyPressed.Key == ConsoleKey.DownArrow || keyPressed.Key == ConsoleKey.S) &&
                Alignment == Orientation.Vertical && Index < Options.Count - 1)
            {
                Index++;
                return keyPressed;
            }
            else if ((keyPressed.Key == ConsoleKey.LeftArrow || keyPressed.Key == ConsoleKey.A) &&
                Alignment == Orientation.Horizontal && Index > 0)
            {
                Index--;
                return keyPressed;
            }
            else if ((keyPressed.Key == ConsoleKey.RightArrow || keyPressed.Key == ConsoleKey.D) &&
                Alignment == Orientation.Horizontal && Index < Options.Count - 1)
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

public enum Orientation { Vertical, Horizontal }
