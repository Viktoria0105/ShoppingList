using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.DataAccess.Entities;

[Table("history")]
public class HistoryEntity : BaseEntity
{
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    
    public int HistoryListId { get; set; }
    public ShoppingListEntity ShoppingList { get; set; }
    
    public DateTime DateAndTime { get; set; }
    public string Data { get; set; }
}