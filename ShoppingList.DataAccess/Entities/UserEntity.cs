using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ShoppingList.DataAccess.Entities;

[Table("users")]
public class UserEntity:IdentityUser<int>, IBaseEntity
{
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
    
    public string Surname{ get; set; }
    public string Name { get; set; }
    
    public int RoleId { get; set; }
    public RoleEntity Role { get; set; }
    
    public ICollection<ShoppingListUsersEntity> ShoppingListUsers { get; set; } = new List<ShoppingListUsersEntity>();
    public ICollection<HistoryEntity> History { get; set; } = new List<HistoryEntity>();
}