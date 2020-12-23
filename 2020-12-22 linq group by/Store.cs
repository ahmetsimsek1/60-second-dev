public class Store
{
    public int StoreID { get; set; }
    public int CountryID { get; set; }
    public string RegionName { get; set; } = default!;
    public string StoreName { get; set; } = default!;

    public Country Country { get; set; } = default!;
}