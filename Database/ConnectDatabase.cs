//EF
using Microsoft.EntityFrameworkCore;
using BaiTapQuayVideo_EF.Models;

namespace BaiTapQuayVideo_EF.Database
{
    //kế thừa thuộc tính của DataContext
    public class ConnectDatabase :DbContext
    {
        // 2. Constructor chuẩn của DbContext để nhận cấu hình
        public ConnectDatabase(DbContextOptions<ConnectDatabase> options): base(options) { }
        //Dbset tự viết là codefirst
        public DbSet<Product> products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Staffs> staffs { get; set; }
        public DbSet<Customer> customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Luôn gọi phương thức gốc trước

            // Cấu hình mối quan hệ tự tham chiếu cho Categories
            modelBuilder.Entity<Categories>()
                .HasOne(c => c.ParentCategory) 
                .WithMany() 
                .HasForeignKey(c => c.ParentId) 
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
