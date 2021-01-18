using System;

public class Constructor
{
    public Constructor(int fooID, string title, DateTime createDate)
        => (FooID, Title, CreateDate) = (fooID, title, createDate);

    public int FooID { get; set; }
    public string Title { get; set; }
    public DateTime CreateDate { get; set; }
}
