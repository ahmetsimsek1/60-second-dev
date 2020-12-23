using System.Collections.Generic;

public class Country
{
    public int CountryID { get; set; }
    public string CountryName { get; set; } = default!;

    public List<Store> Stores { get; set; } = default!;
}
