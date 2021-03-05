using System;

public abstract record TheBase(string Message);

public record TheImplementation(string Message, int Temperature) : TheBase(Message);


public interface ISomething { void Go(); }

public record Something : ISomething
{
    void ISomething.Go() => Console.WriteLine("go");
}
