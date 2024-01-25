namespace Hangman;

/// <summary>
/// Console for the game. Implements IGameConsole interface.
/// Can read letter from console or print different type of messages
/// </summary>
internal class GameConsole : IGameConsole
{
    /// <summary>
    /// Reads char from console
    /// </summary>
    /// <returns>Read letter</returns>
    public char? GetChar()
    {
        return Console.ReadLine()?.FirstOrDefault();
    }

    /// <summary>
    /// Prints message in console
    /// </summary>
    /// <param name="text">string to print</param>
    public void Message(string text)
    {
        Console.WriteLine(text);
    }

    /// <summary>
    /// Prints success message in console
    /// </summary>
    /// <param name="text">string to print</param>
    public void Success(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// Prints warning message in console
    /// </summary>
    /// <param name="text">string to print</param>
    public void Warning(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// Prints error message in console
    /// </summary>
    /// <param name="text">string to print</param>
    public void Error(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
