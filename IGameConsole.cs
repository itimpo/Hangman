namespace Hangman;


/// <summary>
/// Console interface to make some abstration from Infractructure
/// </summary>
internal interface IGameConsole
{
    char? GetChar();
    void Message(string text);
    void Success(string text);
    void Warning(string text);
    void Error(string text);
}
