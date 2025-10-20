using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.DataAccess.Entities;

public class FileEntity:BaseEntity
{
    public string FileName { get; set; }
    public string FileType { get; set; }
    public string Size { get; set; }
    public string FileContent { get; set; }
    
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; }
}