using DPM.Domain.Entities;
using DPM.Domain.Enums;
using Microsoft.EntityFrameworkCore;
namespace DPM.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected DbSet<Fishermen> Fishermens { get; set; }
        protected DbSet<CertificateShip> CertificateShips { get; set; }
        protected DbSet<CertificateShipHistory> CertificateShipHistories { get; set; }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.Property(e => e.Id).IsRequired().HasColumnType("bigint").HasDefaultValueSql("generate_id()");
                entity.Property(e => e.Email).HasColumnType("varchar(128)");
                entity.Property(e => e.FullName).HasColumnType("varchar(64)");
                entity.Property(e => e.Address).HasColumnType("varchar(256)");
                entity.Property(e => e.PhoneNumber).IsRequired().HasColumnType("varchar(16)");
                entity.Property(e => e.Avatar).HasColumnType("varchar(256)");
                entity.Property(e => e.Gender).HasColumnType("varchar(8)").HasConversion<string>();
                entity.Property(e => e.RoleType).IsRequired().HasColumnType("varchar(16)").HasConversion<string>().HasDefaultValue(RoleType.User);
                entity.Property(e => e.Role).IsRequired().HasColumnType("varchar(16)").HasConversion<string>().HasDefaultValue(Role.None);
                entity.Property(e => e.IsDisabled).HasDefaultValue(false);
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.CognitoSub).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Username).IsUnique();
                entity
                  .HasOne(e => e.Creator)
                  .WithMany()
                  .HasForeignKey(e => e.CreatedBy)
                  .OnDelete(DeleteBehavior.SetNull);
                entity
                    .HasOne(e => e.Updater)
                    .WithMany()
                    .HasForeignKey(e => e.UpdatedBy)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasQueryFilter(e => !e.IsDeleted);


            });
            modelBuilder.Entity<Ship>(entity =>
            {
                entity.ToTable("ships");
                entity.Property(e => e.Id).IsRequired().HasColumnType("bigint").HasDefaultValueSql("generate_id()");
                entity.Property(e => e.ClassNumber).IsRequired().HasColumnType("varchar(128)");
                entity.Property(e => e.Name).IsRequired().HasColumnType("varchar(128)");
                entity.Property(e => e.IMONumber).IsRequired().HasColumnType("varchar(128)");
                entity.Property(e => e.RegisterNumber).IsRequired().HasColumnType("varchar(128)");
                entity.Property(e => e.OwnerId).HasColumnType("bigint");
                entity.Property(e => e.Purpose).IsRequired().HasColumnType("varchar(16)").HasConversion<string>().HasDefaultValue(Purpose.None);
                entity.Property(e => e.GrossTonnage).IsRequired().HasColumnType("varchar(128)");
                entity.Property(e => e.TotalPower).IsRequired().HasColumnType("varchar(128)");
                entity.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
                entity.Property(e => e.CreatedBy).HasColumnType("bigint");
                entity.Property(e => e.UpdatedBy).HasColumnType("bigint");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.IMONumber).IsUnique();
                entity
                  .HasOne(e => e.Owner)
                  .WithOne()
                  .HasForeignKey<Ship>(e => e.OwnerId);
                entity
                  .HasOne(e => e.Creator)
                  .WithMany()
                  .HasForeignKey(e => e.CreatedBy)
                  .OnDelete(DeleteBehavior.SetNull);
                entity
                  .HasOne(e => e.Updater)
                  .WithMany()
                  .HasForeignKey(e => e.UpdatedBy)
                  .OnDelete(DeleteBehavior.SetNull);
                entity.HasQueryFilter(e => !e.IsDeleted);

            });

            modelBuilder.Entity<Fishermen>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().HasColumnType("bigint").HasDefaultValueSql("generate_id()");
                entity
                  .HasOne(e => e.User)
                  .WithOne()
                  .HasForeignKey<User>(e => e.Id);
                 entity.HasMany(e => e.FishingTripHistories) 
                  .WithOne(e => e.Fishermen) 
                  .HasForeignKey(e => e.FishermenId) 
                  .IsRequired(false);
                entity.Ignore(e => e.CreatedAt);
                entity.Ignore(e => e.UpdatedAt);
            });
            modelBuilder.Entity<AppRole>(entity =>
            {
                entity.ToTable("roles");
                entity.Property(e => e.Id).IsRequired().HasColumnType("bigint").HasDefaultValueSql("generate_id()");
                entity.Property(e => e.RoleName).IsRequired().HasColumnType("varchar(16)").HasConversion(
                e => e.ToString(),
                e => (Role)Enum.Parse(typeof(Role), e))
                .IsUnicode(false); 
                
                entity.Ignore(e => e.CreatedAt);
                entity.Ignore(e => e.UpdatedAt);

            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("userroles");
                entity.Property(e => e.UserId).HasColumnType("bigint");
                entity
                  .HasOne(e => e.User)
                  .WithOne()
                  .HasForeignKey<User>(e => e.Id);
                entity.Property(e => e.RoleId).HasColumnType("bigint");
                entity.Ignore(e => e.CreatedAt);
                entity.Ignore(e => e.UpdatedAt);
            });

            modelBuilder.Entity<FishingTripHistory>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().HasColumnType("bigint").HasDefaultValueSql("generate_id()");
                entity.Property(e => e.FishingTripId).IsRequired();
                entity.HasIndex(e => new { e.FishingTripId });

                entity.HasOne(e => e.FishingTrip)
                .WithOne()
                .HasForeignKey<FishingTrip>(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<FishingTrip>(entity =>
            {
                entity.Property(e => e.ShipStatus).IsRequired().HasColumnType("varchar(16)").HasConversion<string>().HasDefaultValue(ShipStatus.Idle);
                entity.Property(e => e.TripStatus).IsRequired().HasColumnType("varchar(16)").HasConversion<string>().HasDefaultValue(TripStatus.Undefined);
                entity
                  .HasOne(e => e.Creator)
                  .WithMany()
                  .HasForeignKey(e => e.CreatedBy)
                  .OnDelete(DeleteBehavior.SetNull);
                entity
                  .HasOne(e => e.Updater)
                  .WithMany()
                  .HasForeignKey(e => e.UpdatedBy)
                  .OnDelete(DeleteBehavior.SetNull);
                entity.HasQueryFilter(e => e.Ship.IsDeleted);

            });
            modelBuilder.Entity<CertificateShip>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().HasColumnType("bigint").HasDefaultValueSql("generate_id()");
                entity.Property(e => e.CertificateNo).IsRequired();
                entity.Property(e => e.CertificateStatus).IsRequired().HasColumnType("varchar(64)").HasConversion<string>().HasDefaultValue(CertificateStatus.None);
                entity.HasIndex(e => new { e.FishingTripId });

                entity.HasOne(e => e.FishingTrip)
                .WithMany()
                .HasForeignKey(e => e.FishingTripId)
                .OnDelete(DeleteBehavior.Cascade);
                entity.HasQueryFilter(e => e.FishingTrip.IsDeleted);
            });
            modelBuilder.Entity<CertificateShipHistory>(entity =>
            {
                entity
                  .HasOne(e => e.Creator)
                  .WithMany()
                  .HasForeignKey(e => e.CreatedBy)
                  .OnDelete(DeleteBehavior.SetNull);
                entity
                  .HasOne(e => e.Updater)
                  .WithMany()
                  .HasForeignKey(e => e.UpdatedBy)
                  .OnDelete(DeleteBehavior.SetNull);
                entity.HasQueryFilter(e => e.CertificateShip.IsDeleted);

            });
            modelBuilder.Entity<Map>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().HasColumnType("bigint").HasDefaultValueSql("generate_id()");
                entity.HasOne(e => e.Ship)
                .WithOne()
                .HasForeignKey<Map>(e => e.ShipId)
                .OnDelete(DeleteBehavior.Cascade);
                entity.HasQueryFilter(e => e.Ship.IsDeleted);

            });

        }
        public override int SaveChanges()
        {
            throw new NotSupportedException("Only asynchronous operations are supported.");
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            throw new NotSupportedException("Only asynchronous operations are supported.");
        }
        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
    public class ReadOnlyAppDbContext : AppDbContext
    {
        public ReadOnlyAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException("Readonly context");
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException("Readonly context");
        }
    }
}
