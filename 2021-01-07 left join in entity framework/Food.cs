using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Foods")]
public class Food
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FoodID { get; set; }
    public string FoodName { get; set; } = default!;
}
