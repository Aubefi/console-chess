using System;
using Chess.Assets;
using Chess.Assets.ChessPieces;
using Chess.Engine.Bases;

namespace Chess.Scenes.Gameplay;

public class Board : BaseBehavior
{
    public BoardRenderer? Renderer { get; set; }
    public BoardNavigation? Navigation { get; set; }

    private readonly BaseUIObject[,] _boardObjects = new BaseUIObject[8, 8];

    public override void Start()
    {
        BuildBaseGridObjects();
    }

    public override void Update()
    {
        Renderer?.BoardObjects = _boardObjects;
        Renderer?.Render();
        Navigation?.BoardObjects = _boardObjects;
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
            _boardObjects[0, i] = CreatePiece(piecesOrder[i], symbols[piecesOrder[i]], Colors.Pieces["Black"], i, 0);

            // Black pawns
            _boardObjects[1, i] = CreatePiece(SquareObject.Pawn, symbols[SquareObject.Pawn], Colors.Pieces["Black"], i, 1);

            // White pawns
            _boardObjects[6, i] = CreatePiece(SquareObject.Pawn, symbols[SquareObject.Pawn], Colors.Pieces["White"], i, 6);

            // White pieces
            _boardObjects[7, i] = CreatePiece(piecesOrder[i], symbols[piecesOrder[i]], Colors.Pieces["White"], i, 7);
        }

        for (int i = 2; i < 6; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                _boardObjects[i, j]
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
}
