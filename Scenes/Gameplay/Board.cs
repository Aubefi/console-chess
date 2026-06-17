using System;
using Chess.Assets;
using Chess.Engine.Bases;
using Chess.GameObjects.ChessPieces;

namespace Chess.Scenes.Gameplay;

public class Board : BaseBehavior
{
    public BoardRenderer? Renderer { get; set; }
    public BoardNavigation? Navigation { get; set; }

    public readonly BaseUIObject[,] BoardObjects = new BaseUIObject[8, 8];

    public override void Start()
    {
        BuildBaseGridObjects();
    }

    public override void Update()
    {
        Renderer?.BoardObjects = BoardObjects;
        Renderer?.Render();
        Navigation?.BoardObjects = BoardObjects;
    }

    private void BuildBaseGridObjects()
    {
        SquareObject[] piecesOrder = [
            SquareObject.Rook, SquareObject.Knight, SquareObject.Bishop, SquareObject.Queen,
            SquareObject.King, SquareObject.Bishop, SquareObject.Knight, SquareObject.Rook
        ];

        var symbols = Symbols.Square;

        for (int i = 0; i < 8; i++)
        {
            // Black pieces
            BoardObjects[0, i] = CreatePiece(piecesOrder[i], symbols[piecesOrder[i]], Colors.Pieces["Black"], i, 0);

            // Black pawns
            BoardObjects[1, i] = CreatePiece(SquareObject.Pawn, symbols[SquareObject.Pawn], Colors.Pieces["Black"], i, 1);
            SetPawnDirection(BoardObjects[1, i], PawnDirection.Black);

            // White pawns
            BoardObjects[6, i] = CreatePiece(SquareObject.Pawn, symbols[SquareObject.Pawn], Colors.Pieces["White"], i, 6);
            SetPawnDirection(BoardObjects[6, i], PawnDirection.White);

            // White pieces
            BoardObjects[7, i] = CreatePiece(piecesOrder[i], symbols[piecesOrder[i]], Colors.Pieces["White"], i, 7);
        }

        for (int i = 2; i < 6; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                BoardObjects[i, j]
                    = CreatePiece(SquareObject.Blank, symbols[SquareObject.Blank], Colors.Square["Blank"], j, i);
            }
        }
    }

    private static BaseUIObject CreatePiece(SquareObject type, char symbol, ConsoleColor color, int x, int y)
    {
        return type switch
        {
            SquareObject.King => new King(symbol, color, x, y),
            SquareObject.Queen => new Queen(symbol, color, x, y),
            SquareObject.Rook => new Rook(symbol, color, x, y),
            SquareObject.Knight => new Knight(symbol, color, x, y),
            SquareObject.Bishop => new Bishop(symbol, color, x, y),
            SquareObject.Pawn => new Pawn(symbol, color, x, y),
            _ => new Blank(symbol, color, x, y)
        };
    }

    private static void SetPawnDirection(BaseUIObject obj, PawnDirection direction)
    {
        if (obj is Pawn pawn)
        {
            pawn.SetPawnDirection(direction);
        }
    }
}
