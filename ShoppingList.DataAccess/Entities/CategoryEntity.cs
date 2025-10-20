using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.DataAccess.Entities;

public class CategoryEntity : BaseEntity
{
    public string Name { get; set; }
    
    public ICollection<ProductEntity> Product { get; set; } = new List<ProductEntity>();
}