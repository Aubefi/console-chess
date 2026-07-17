using Chess.Assets;
using Chess.Engine.Bases;

namespace Chess.GameObjects.ChessPieces;

public class Blank(int x, int y)
: BaseUIObject(Symbols.Square[SquareObject.Blank], Colors.Square["Blank"], x, y)
{
}
