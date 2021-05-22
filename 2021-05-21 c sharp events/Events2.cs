using System;

// More compact syntax: inline lambda for handling the event, using built-in EventHandler<> delegate type,
// using null conditional operator to invoke event

public class Events2
{
    private static readonly Random _random = new();
    public void Go()
    {
        Car car = new();
        car.GotTicket += (sender, e) => Console.WriteLine(e);

        while (car.Speed < 80)
        {
            Console.WriteLine($"You are currently going {car.Speed} MPH");
            car.Accelerate(_random.Next(25));
        }
    }
}

public class TicketEventArgs
    : EventArgs
{
    private readonly int _mph, _fineAmount;
    public TicketEventArgs(int mph, int fineAmount) => (_mph, _fineAmount) = (mph, fineAmount);

    public override string ToString() => $"You got fined ${_fineAmount} for going {_mph} MPH";
}

class Car
{
    public event EventHandler<TicketEventArgs> GotTicket;

    private int _speed;
    private static Random _random = new();
    public void Accelerate(int increase)
    {
        _speed += increase;
        if (_speed > 80)
        {
            int fineAmount = _random.Next(300, 600);
            GotTicket?.Invoke(this, new TicketEventArgs(_speed, fineAmount));
        }
    }

    public int Speed => _speed;
}
