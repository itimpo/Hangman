namespace Hangman;

/// <summary>
/// Contains all game logic
/// </summary>
/// <param name="settings">settings for the game</param>
/// <param name="console">input/output console for the game</param>
class Game(Settings settings, IGameConsole console)
{
    private readonly Settings _settings = settings;
    private IGameConsole _console = console;

    private readonly List<char> _guessedLetters = [];
    private string _word = String.Empty;
    private int _currentAttempts = 0;

    /// <summary>
    /// Checks and return True if the game is finished
    /// </summary>
    public bool IsFinished
    => _currentAttempts >= _settings.MaxAttempts
       || _guessedLetters.Count() == _word.ToCharArray().GroupBy(c => c).Count();


    /// <summary>
    /// Selects random word from the list
    /// </summary>
    /// <param name="word">Optional word (for testing)</param>
    /// <returns>Selected word</returns>
    public string SelectWord(string? word = null)
    {
        return _word = word ?? _settings.Words[Random.Shared.Next(0, _settings.Words.Length)];
    }

    /// <summary>
    /// Prints request for user and gets guess letter
    /// </summary>
    /// <returns>Entered letter or null</returns>
    public char? GetGuess()
    {
        // Get the player's guess
        _console.Message("Enter your guess:");
        return _console.GetChar();
    }

    /// <summary>
    /// Checks is word contains the letter and updates state
    /// </summary>
    /// <param name="guess">guess letter</param>
    /// <returns>True if the word contains the letter</returns>
    public bool IsContainsLetter(char guess)
    {
        // Check if the guess is correct
        var contains = _word.Contains(guess);

        if (contains && _guessedLetters.Contains(guess))
        {
            _console.Warning("You already used this letter");
            return true;
        }

        UpdateState(guess, contains);

        var attempts = _settings.MaxAttempts - _currentAttempts;
        var result = new string(_word.ToCharArray().Select(c => _guessedLetters.Contains(c) ? c : '_').ToArray());

        if (contains)
        {
            _console.Success($":) > {attempts}\t{result}");
        }
        else
        {
            _console.Error($":( > {attempts}\t{result}");
        }

        return contains;
    }

    /// <summary>
    /// Prints game result
    /// </summary>
    public void PrintResult()
    {
        if (_currentAttempts >= _settings.MaxAttempts)
        {
            _console.Error($"You lose! The word was: {_word}");
        }
        else
        {
            _console.Success($"You win! The word was: {_word}");
        }
    }

    /// <summary>
    /// Add the guess to the list of guessed letters
    /// </summary>
    /// <param name="guess">the letter</param>
    /// <param name="isCorrect">is word contains this letter</param>
    private void UpdateState(char guess, bool isCorrect)
    {
        if (isCorrect)
        {
            _guessedLetters.Add(guess);
        }
        else
        {
            _currentAttempts++;
        }
    }
}