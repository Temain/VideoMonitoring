using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using VideoMonitoring.Domain.Models;
using VideoMonitoring.Web.Extensions;

namespace VideoMonitoring.Domain.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, long>
	{
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);

			builder.Entity<User>().ToTable("asp_user");
			builder.Entity<IdentityRole<long>>().ToTable("asp_role");
			builder.Entity<IdentityUserClaim<long>>().ToTable("asp_user_claim");
			builder.Entity<IdentityUserLogin<long>>().ToTable("asp_user_login");
			builder.Entity<IdentityUserRole<long>>().ToTable("asp_user_role");
			builder.Entity<IdentityUserToken<long>>().ToTable("asp_user_token");
			builder.Entity<IdentityRoleClaim<long>>().ToTable("asp_role_claim");

			foreach (var entity in builder.Model.GetEntityTypes())
			{
				// Replace table names
				entity.Relational().TableName = entity.Relational().TableName.ToSnakeCase();

				// Replace column names            
				foreach (var property in entity.GetProperties())
				{
					property.Relational().ColumnName = property.Name.ToSnakeCase();
				}

				foreach (var key in entity.GetKeys())
				{
					key.Relational().Name = key.Relational().Name.ToSnakeCase();
				}

				foreach (var key in entity.GetForeignKeys())
				{
					key.Relational().Name = key.Relational().Name.ToSnakeCase();
				}

				foreach (var index in entity.GetIndexes())
				{
					index.Relational().Name = index.Relational().Name.ToSnakeCase();
				}
			}
		}
    }
}
