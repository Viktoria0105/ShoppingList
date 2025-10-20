using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.DataAccess.Entities;

public class ProductsInListEntity:BaseEntity
{
    public int ShoppingListId { get; set; }
    public ShoppingListEntity ShoppingList { get; set; }
    
    public int ProductId { get; set; }
    public ProductEntity Product{ get; set; }
}