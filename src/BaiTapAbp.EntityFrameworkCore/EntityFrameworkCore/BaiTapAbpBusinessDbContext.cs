using BaiTapAbp.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BaiTapAbp.EntityFrameworkCore;

[ConnectionStringName("BaiTapAbpBusiness")]
public class BaiTapAbpBusinessDbContext(DbContextOptions<BaiTapAbpBusinessDbContext> options)
 : AbpDbContext<BaiTapAbpBusinessDbContext>(options)
{
 public virtual DbSet<ProductEntity> Products { get; set; }
 public virtual DbSet<ShopEntity> Shops { get; set; }
 
 protected override void OnModelCreating(ModelBuilder builder)
 {
  base.OnModelCreating(builder);

  builder.Entity<ShopEntity>(s =>
  {
   s.ToTable("Shop");
   s.ConfigureByConvention();
   s.Property(x => x.Name).IsRequired().HasMaxLength(100);
   s.Property(x=>x.Address).HasMaxLength(100);
  });
  builder.Entity<ProductEntity>(p =>
  {
   p.ToTable("Product");
   p.ConfigureByConvention();
   p.Property(x => x.Name).IsRequired().HasMaxLength(100);
   p.Property(x => x.Price)
    .HasColumnType("decimal(18,2)");
   p.Property(x => x.Stock);
   
   p.HasOne<ShopEntity>()
    .WithMany()
    .HasForeignKey(p=> p.ShopId)
    .OnDelete(DeleteBehavior.Restrict);
  });
 }
}