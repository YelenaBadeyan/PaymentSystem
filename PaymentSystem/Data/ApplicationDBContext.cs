using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PaymentSystem.Data.Entities;

namespace PaymentSystem.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<UserRelation> UserRelations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2); // total digits: 18, decimals: 2

            modelBuilder.Entity<UserRelation>(entity =>
            {
                entity.HasKey(ur => new { ur.FirstUserId, ur.SecondUserId }); 
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(ur => ur.FirstUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(ur => ur.SecondUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(ur => ur.RelationType)
                    .IsRequired();
            });
        }

    }
}
