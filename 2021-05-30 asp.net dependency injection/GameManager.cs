using System;

public class GameManager : IGameManager, IDisposable
{
    string IGameManager.GetGameName()
        => "Space Invaders";

    void IDisposable.Dispose() => Console.WriteLine("GameManager was disposed");
}