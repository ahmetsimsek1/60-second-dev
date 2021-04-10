using System;

public record CarModel
{
    public string Make { get; init; }
    public string Model { get; init; }
    public DateTimeOffset BuyDate { get; init; }
    public string GetLocalBuyDate()
        => TimeZoneInfo.ConvertTimeBySystemTimeZoneId(BuyDate, "America/Phoenix").ToString();
}