using Chess.Assets;
using Chess.Assets.ChessPieces;
using Chess.Engine.Bases;

namespace Chess.Scripts;

public class PawnScript()
{
    public static void MovePawn(Pawn pawn, Position targetPos)
    {
        var distance = pawn.HasMoved ? 1 : 2;

        var isMoveAllowed = pawn.Color switch
        {
            var w when w == Colors.Pieces["White"] => targetPos.Y >= pawn.Pos.Y - distance,
            var b when b == Colors.Pieces["Black"] => targetPos.Y <= pawn.Pos.Y + distance,
            _ => false
        };

        if (isMoveAllowed is false)
            return;

        pawn.SetPosition(targetPos);
    }
}
