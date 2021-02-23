using System;
using CsvHelper.Configuration.Attributes;

public class Item
{
    public Item(int itemID, string description, DateTime createDate,
        DateTime? inStockDate, decimal price, int? parentItemID)
        => (ItemID, Description, CreateDate, InStockDate, Price, ParentItemID)
        = (itemID, description, createDate, inStockDate, price, parentItemID);


    [Index(6), Name("the price")]
    public decimal Price { get; }

    [Index(5), Format("yyyyMMdd\\-HHmmss\\.fff")]
    public DateTime CreateDate { get; }

    [Index(4), Name("parent id")]
    public int? ParentItemID { get; }

    [Index(1)]
    public int ItemID { get; }

    [Index(2)]
    public string Description { get; }

    [Index(3)]
    public DateTime? InStockDate { get; }
}
