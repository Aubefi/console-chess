namespace Chess;

public sealed class Program
{
    public static void Main()
        => ChessGame().Run();

    private static Game ChessGame()
        => new();
}
