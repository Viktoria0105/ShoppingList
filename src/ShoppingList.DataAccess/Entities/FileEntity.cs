using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.DataAccess.Entities;

[Table("files")]

public class FileEntity : BaseEntity
{
    public string FileName { get; set; }
    public string FileType { get; set; }
    public double Size { get; set; }
    public byte FileContent { get; set; }
    
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; }
}