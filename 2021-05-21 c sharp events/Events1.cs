using System;
using System.Threading;

// Traditional event structure: Separate method for handling the event, declaring a new delegate,
// checking for null before executing event.

public class Events1
{
    public void Go()
    {
        TicTacToeGame game = new();
        game.GameOver += OnGameOver;

        for (int i = 0; i < 9; ++i)
        {
            Console.WriteLine($"Playing round {i}");
            game.PlaySquare(i % 2, i);
            if (game.Result.HasValue)
            {
                break;
            }
        }
    }

    private static void OnGameOver(object sender, GameOverEventArgs e)
        => Console.WriteLine($"Game Over: sender={sender}, e={e}");
}

enum GameResult { PlayerOneWins, PlayerTwoWins, Draw }
class GameOverEventArgs
    : EventArgs
{
    private GameResult _gameResult;
    public GameOverEventArgs(GameResult gameResult) => _gameResult = gameResult;
}
class TicTacToeGame
{
    public delegate void GameOverHandler(object sender, GameOverEventArgs e);
    public event GameOverHandler GameOver;

    private GameResult? _gameResult;
    public void PlaySquare(int playerNumber, int squareNumber)
    {
        // TODO: implementation
        if (IsGameOver())
        {
            if (GameOver != null)
            {
                GameOver(this, new GameOverEventArgs(_gameResult.Value));
            }
        }
        Thread.Sleep(200);
    }

    private static Random _random = new();
    private bool IsGameOver()
    {
        // TODO: implementation
        bool isGameOver = _random.Next(0, 3) == 1;
        if (isGameOver)
        {
            _gameResult = (GameResult)_random.Next(0, 3);
        }
        return isGameOver;
    }

    public GameResult? Result => _gameResult;
}