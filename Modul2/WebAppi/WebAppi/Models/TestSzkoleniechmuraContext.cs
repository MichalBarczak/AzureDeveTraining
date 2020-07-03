using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppi.Models
{
    public partial class TestSzkoleniechmuraContext : DbContext
    {
        public TestSzkoleniechmuraContext()
        {
        }

        public TestSzkoleniechmuraContext(DbContextOptions<TestSzkoleniechmuraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:testdbserverszkoleniechmura.database.windows.net,1433;Initial Catalog=TestSzkoleniechmura;Persist Security Info=False;User ID=adminszkolenie;Password=ZnAGAjyGPVnT5MUVo4tg;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApartmentNumber).HasColumnName("Apartment_Number");

                entity.Property(e => e.City)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.HouseNumber)
                    .IsRequired()
                    .HasColumnName("House_Number")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IsMainAddress).HasColumnName("Is_MainAddress");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasColumnName("Zip_Code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address__UserID__52593CB8");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Prize).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("Order_Item");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.NumberOfItems)
                    .HasColumnName("Number_Of_Items")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Prize).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Ite__ItemI__59FA5E80");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Ite__Order__5AEE82B9");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnName("Status_Name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TotalPrize)
                    .HasColumnName("Total_Prize")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__AddressI__5629CD9C");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__StatusId__5535A963");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__UserID__4D94879B");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddresId).HasColumnName("AddresID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
