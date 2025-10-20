using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.DataAccess.Entities;

public class ShoppingListUsersEntity:BaseEntity
{
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    
    public int ShoppingListId { get; set; }
    public ShoppingListEntity ShoppingList { get; set; }
}