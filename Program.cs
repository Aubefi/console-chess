namespace Chess;

public sealed class Program
{
    public static void Main()
        => ChessGame().Run();

    public static Game ChessGame()
        => new();
}
