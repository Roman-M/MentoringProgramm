using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EF_Task
{
	public class Context : DbContext
	{
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Good> Goods { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Client> Clients { get; set; }
		
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Initial
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

			// Add client 
			modelBuilder.Entity<Client>()
				.HasKey(t => t.ID)
				.Property(t => t.Login)
				.HasMaxLength(50);

			modelBuilder.Entity<Client>()
				.Property(t => t.FIO)
				.HasMaxLength(100);

			modelBuilder.Entity<Payment>()
				.Property(t => t.ClientID)
				.HasColumnName("Client");

			modelBuilder.Entity<Payment>()
				.HasRequired(t => t.Client)
				.WithMany(t => t.Payments)
				.HasForeignKey(t => t.ClientID);

			// Add payment types 
			modelBuilder.Entity<Payment>()
				.Map<CashPayment>(m => m.Requires("Type")
					.HasValue("Cash"))
				.Map<BankCard>(m => m.Requires("Type")
					.HasValue("BankCard"))
				.Map<WebMoney>(m => m.Requires("Type")
					.HasValue("WebMoney"))
				.Map<PayPal>(m => m.Requires("Type")
					.HasValue("PayPal")); 

			base.OnModelCreating(modelBuilder);
		}
	}
}
