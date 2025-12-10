using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using ShoppingList.DataAccess.Entities.Primitives;

namespace ShoppingList.DataAccess.Entities;

[Table("roles")]
public class RoleEntity : BaseEntity
{
    Role NameRole { get; set; }
    public ICollection<UserEntity> User { get; set; } = new List<UserEntity>();
}