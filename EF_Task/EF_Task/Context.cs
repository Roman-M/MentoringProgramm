using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System;

namespace EF_Task
{
	public class Context : DbContext
	{
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Good> Goods { get; set; }
		public DbSet<Category> Categories { get; set; }
		//public DbSet<Client> Clients { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Good>()
				.HasKey(t => t.ID)
				.Property(t => t.ID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			modelBuilder.Entity<Good>()
				.Property(t => t.Amount)
				.HasPrecision(10, 2);
			
			modelBuilder.Entity<Good>()
				.Property(t => t.Name)
				.HasMaxLength(250)
				.IsRequired();

			modelBuilder.Entity<Payment>()
				.HasKey(t => t.ID)
				.Property(t => t.ID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			modelBuilder.Entity<Payment>()
				.Property(t => t.GoodId)
				.HasColumnName("Good");

			modelBuilder.Entity<Payment>()
				.HasRequired(t => t.Good)
				.WithMany(t => t.Payments)
				.HasForeignKey(t => t.GoodId);

			modelBuilder.Entity<Category>()
				.Property(t => t.Name)
				.HasMaxLength(150)
				.IsRequired();

			modelBuilder.Entity<Category>()
				.Property(t => t.Parent_Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.IsOptional();

			modelBuilder.Entity<Category>()
				.HasOptional(t => t.ParentCategory)
				.WithMany()
				.HasForeignKey(t => t.Parent_Id);

			modelBuilder.Entity<Category>()
				.HasMany(t => t.Goods)
				.WithMany(t => t.Categories)
				.Map(m =>
				{
					m.MapLeftKey("Category");
					m.MapRightKey("Good");
					m.ToTable("Structure");
				});

			//modelBuilder.Entity<Client>()
			//	.Property(t => t.Login)
			//	.HasMaxLength(50);

			//modelBuilder.Entity<Client>()
			//	.Property(t => t.FIO)
			//	.HasMaxLength(100);

			//modelBuilder.Entity<Payment>()
			//	.Property(t => t.ClientID)
			//	.HasColumnName("Client")
			//	.IsRequired();

			//modelBuilder.Entity<Payment>()
			//	.HasRequired(t => t.Client)
			//	.WithRequiredPrincipal(t => t.Payment);

			base.OnModelCreating(modelBuilder);
		}
	}
}
