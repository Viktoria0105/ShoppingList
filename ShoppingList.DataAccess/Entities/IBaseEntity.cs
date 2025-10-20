namespace ShoppingList.DataAccess.Entities;

public interface IBaseEntity
{
    public int Id { get; set; } //ключ в бд

    public Guid ExternalId { get; set; } // unique index
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; } 
}