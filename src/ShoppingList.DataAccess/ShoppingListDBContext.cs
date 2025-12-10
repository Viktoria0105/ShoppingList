using ShoppingList.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ShoppingList.DataAccess;

public class ShoppingListDbContext:DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ShoppingListEntity> ShoppingLists { get; set; }
    public DbSet<HistoryEntity> History { get; set; }
    public DbSet<ShoppingListUsersEntity> ShoppingListUsers { get; set; }
    public DbSet<ProductsInListEntity> ProductsInList { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<FileEntity> Files { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    
    public ShoppingListDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //default identity server tables
        modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("user_claims");
        modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("user_logins").HasNoKey();
        modelBuilder.Entity<IdentityUserToken<int>>().ToTable("user_tokens").HasNoKey();
        modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("user_role_claims");
        modelBuilder.Entity<IdentityUserRole<int>>().ToTable("user_role_owners").HasNoKey();
        
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<UserEntity>().HasOne(x => x.Role)
            .WithMany(x => x.User)
            .HasForeignKey(x => x.RoleId);

        modelBuilder.Entity<ShoppingListEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ShoppingListEntity>().HasIndex(x => x.ExternalId).IsUnique();
        
        modelBuilder.Entity<CategoryEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<CategoryEntity>().HasIndex(x => x.ExternalId).IsUnique();

        modelBuilder.Entity<HistoryEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<HistoryEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<HistoryEntity>().HasOne(x => x.ShoppingList)
            .WithMany(x => x.History)
            .HasForeignKey(x => x.HistoryListId);
        modelBuilder.Entity<HistoryEntity>().HasOne(x => x.User)
            .WithMany(x => x.History)
            .HasForeignKey(x => x.UserId);
        
        modelBuilder.Entity<ShoppingListUsersEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ShoppingListUsersEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<ShoppingListUsersEntity>().HasOne(x => x.ShoppingList)
            .WithMany(x => x.ShoppingListUsers)
            .HasForeignKey(x => x.ShoppingListId);
        modelBuilder.Entity<ShoppingListUsersEntity>().HasOne(x => x.User)
            .WithMany(x => x.ShoppingListUsers)
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<ProductsInListEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ProductsInListEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<ProductsInListEntity>().HasOne(x => x.Product)
            .WithMany(x => x.ProductsInList)
            .HasForeignKey(x => x.ProductId);
        modelBuilder.Entity<ProductsInListEntity>().HasOne(x => x.ShoppingList)
            .WithMany(x => x.ProductsInList)
            .HasForeignKey(x => x.ShoppingListId);

        modelBuilder.Entity<ProductEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ProductEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<ProductEntity>().HasOne(x => x.Category)
            .WithMany(x => x.Product)
            .HasForeignKey(x => x.CategoryId);
        modelBuilder.Entity<ProductEntity>().HasCheckConstraint("CK_ProductEntity_Cost", "\"Cost\" > 0");
        
        modelBuilder.Entity<FileEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<FileEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<FileEntity>().HasOne(x => x.Product)
            .WithMany(x => x.File)
            .HasForeignKey(x => x.ProductId);
    }
}