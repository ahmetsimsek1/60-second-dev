using System;

record Transaction(DateTime Date, string Description)
{
    public string Date_Formatted => Date.ToString("MMM dd yyyy");
}
