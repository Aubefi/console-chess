using System;

namespace Chess.Engine;

public enum InputMap
{
    Left, Up, Down, Right, Interact, Escape
}

public static class Input
{
    public static event Action<InputMap>? InputAction;
    public static event Action? RedrawScene;

    public static void ReadInput()
    {
        var input = Console.ReadKey(true);

        switch (input.Key)
        {
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                InputAction?.Invoke(InputMap.Up);
                break;

            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                InputAction?.Invoke(InputMap.Left);
                break;

            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                InputAction?.Invoke(InputMap.Down);
                break;

            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                InputAction?.Invoke(InputMap.Right);
                break;

            case ConsoleKey.Spacebar:
            case ConsoleKey.Enter:
                InputAction?.Invoke(InputMap.Interact);
                break;

            case ConsoleKey.Escape:
                InputAction?.Invoke(InputMap.Escape);
                break;

            case ConsoleKey.R:
                RedrawScene?.Invoke();
                break;

            default:
                break;
        }
    }
}
