using System.Text.Json;

namespace Hangman;

class Program
{
    static void Main(string[] args)
    {
        var console = new GameConsole();

        // read settings from file
        var settings = JsonSerializer.Deserialize<Settings>(File.ReadAllText("appsettings.json"));

        if(settings == null)
        {
            console.Error("Settings file is invalid");
            return;
        }

        // create and initialize the game
        var game = new Game(settings, console);

        // select word
        var word = game.SelectWord();

#if DEBUG
        console.Warning($"DEBUG: Selected word: {word}");
#endif

        // start game
        while (!game.IsFinished)
        {
            // get char from console
            var letter = game.GetGuess();
            if (!letter.HasValue)
            {
                continue;
            }

            // check the letter
            game.IsContainsLetter(letter.Value);
        }

        // print out game results
        game.PrintResult();
    }
}    