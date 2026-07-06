using System;
using Chess.Assets;

namespace Chess.Scenes.Gameplay;

public sealed class GameplayState
{
    public ConsoleColor CurrentPlayerColor { get; private set; } = Colors.Pieces["White"];

    public bool IsWhiteToMove
    {
        get;
        set
        {
            CurrentPlayerColor = value is true
                ? Colors.Pieces["White"]
                : Colors.Pieces["Black"];

            field = value;
        }
    } = true;
}
