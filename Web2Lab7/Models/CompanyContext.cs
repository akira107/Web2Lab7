using Microsoft.EntityFrameworkCore;
namespace Web2Lab7.Models
{
    public class CompanyContext : DbContext
    {
        //public CompanyContext()
        //{

        //}
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {

        }

        public DbSet<Department>Department { get; set; }
        public DbSet<Employee>Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Designation).IsRequired().HasMaxLength(25).IsUnicode(false);

                entity.Property(e => e.Name).IsRequired().HasMaxLength(100).IsUnicode(false);

                entity.HasOne(d => d.Department).WithMany(p => p.Employee)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Department");
            });
        }
    }
}
