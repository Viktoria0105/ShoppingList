using System.ComponentModel.DataAnnotations.Schema;
using ShoppingList.DataAccess.Entities.Primitives;

namespace ShoppingList.DataAccess.Entities;


[Table("categories")]
public class CategoryEntity : BaseEntity
{
    public Category Name { get; set; }
    
    public ICollection<ProductEntity> Product { get; set; } = new List<ProductEntity>();
}