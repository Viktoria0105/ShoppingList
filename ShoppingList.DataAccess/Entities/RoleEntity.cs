using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ShoppingList.DataAccess.Entities;

[Table("roles")]
public class RoleEntity:IdentityRole<int>
{
    public ICollection<UserEntity> User { get; set; } = new List<UserEntity>();
}