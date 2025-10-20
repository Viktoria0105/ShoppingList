using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.DataAccess.Entities;

public class ProductEntity:BaseEntity
{
    public string Name { get; set; }
    public int Cost { get; set; }
    public string Description { get; set; }
    
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; }
    
    public ICollection<FileEntity> File { get; set; } = new List<FileEntity>();
    public ICollection<ProductsInListEntity> ProductsInList { get; set; } = new List<ProductsInListEntity>();
}