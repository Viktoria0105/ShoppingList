using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.DataAccess.Entities;

[Table("shopping_lists")]

public class ShoppingListEntity : BaseEntity
{
    public DateTime CreatedOn { get; set; }
    
    public ICollection<ProductsInListEntity> ProductsInList { get; set; } = new List<ProductsInListEntity>();
    public ICollection<HistoryEntity> History { get; set; } = new List<HistoryEntity>();
    public ICollection<ShoppingListUsersEntity> ShoppingListUsers { get; set; } = new List<ShoppingListUsersEntity>();
}