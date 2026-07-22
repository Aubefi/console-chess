using System;
using Chess.Engine.Bases;

namespace Chess.Scenes.Gameplay;

public sealed class OptionsCursor : BaseCursor
{
    public override Position Pos
    {
        get;
        protected set
        {
            LastPosition = field;
            field = value;
        }
    }

    public Position LastPosition { get; set; }

    public int MaxIndex
    {
        get;
        set => field = value - 1;
    } = 0;

    public OptionsCursor(char symbol, ConsoleColor color, int x, int y) : base(symbol, color, x, y)
    {
        Pos = new(x, y);
        LastPosition = Pos;
    }

    public bool HasMoved
    {
        get => field = LastPosition != Pos;
        private set;
    }
}
