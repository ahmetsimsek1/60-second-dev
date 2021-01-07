using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("People")]
public class Person
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PersonID { get; set; }
    public string FirstName { get; set; } = default!;
    public int? FavoriteFoodID { get; set; }

    [ForeignKey(nameof(FavoriteFoodID))]
    public Food? FavoriteFood { get; set; }
}