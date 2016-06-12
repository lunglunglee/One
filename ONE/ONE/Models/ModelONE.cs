namespace ONE.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelONE : DbContext
    {
        public ModelONE()
            : base("name=ModelONE")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Data_Area> Data_Area { get; set; }
        public virtual DbSet<Data_City> Data_City { get; set; }
        public virtual DbSet<Data_Province> Data_Province { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Main_Employees> Main_Employees { get; set; }
        public virtual DbSet<Order_Details> Order_Details { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Order_Details)
                .WithRequired(e => e.Categories)
                .HasForeignKey(e => e.訂購貨品)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Data_City>()
                .HasMany(e => e.Data_Area)
                .WithRequired(e => e.Data_City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Data_Province>()
                .HasMany(e => e.Data_City)
                .WithRequired(e => e.Data_Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Main_Employees>()
                .HasMany(e => e.Order_Details)
                .WithRequired(e => e.Main_Employees)
                .HasForeignKey(e => e.訂購代理)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order_Details>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Orders>()
                .HasOptional(e => e.Order_Details)
                .WithRequired(e => e.Orders);

            modelBuilder.Entity<Products>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Suppliers>()
                .Property(e => e.產品名稱)
                .IsFixedLength();

            modelBuilder.Entity<Suppliers>()
                .Property(e => e.採購項目)
                .IsFixedLength();

            modelBuilder.Entity<Suppliers>()
                .Property(e => e.價錢)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Suppliers>()
                .Property(e => e.數量)
                .IsFixedLength();

            modelBuilder.Entity<Suppliers>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Suppliers)
                .HasForeignKey(e => e.供應商)
                .WillCascadeOnDelete(false);
        }
    }
}
