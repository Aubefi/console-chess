using System;
using Chess.Objects;

namespace Chess.Scripts;

public class PawnScript()
{
    public static void MovePawn(Pawn pawn, Position targetPos)
    {
        var distance = pawn.HasMoved ? 1 : 2;

        var isMoveAllowed = pawn.Color switch
        {
            ConsoleColor.White => targetPos.Y >= pawn.Coordinates.Y - distance,
            ConsoleColor.Gray => targetPos.Y <= pawn.Coordinates.Y + distance,
            _ => false
        };

        if (isMoveAllowed is false)
            return;

        pawn.SetPosition(targetPos);
    }
}
