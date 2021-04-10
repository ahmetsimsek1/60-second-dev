using System;

var dt = new DateTime(2021, 4, 10, 8, 7, 0); // April 10th 2021, 08:07:00
var now = DateTime.Now; // Current local time

Console.WriteLine(DateTime.MinValue.Ticks); // 0
Console.WriteLine(DateTime.MinValue.AddSeconds(1).Ticks.ToString("#,##0")); // 10,000,000

var arizonaOffset = TimeSpan.FromHours(-7);
var dto = new DateTimeOffset(dt, arizonaOffset);

Console.WriteLine($"Offset Time: {dto}"); // 4/10/2021 8:07:00 AM -07:00
Console.WriteLine($"UTC Time: {dto.UtcDateTime}"); // 4/10/2021 3:07:00 PM

var car = new CarEntity { Make = "Chevy", BuyDate = DateTime.UtcNow };
SaveCar(car);
static void SaveCar(CarEntity car) { /* Save to DB */ }

var carModel = new CarModel { Make = car.Make, BuyDate = car.BuyDate };
Console.WriteLine($"UTC: {carModel.BuyDate}");
Console.WriteLine($"Local: {carModel.GetLocalBuyDate()}");
