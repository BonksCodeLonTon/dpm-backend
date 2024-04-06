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
                entity.Property(e => e.RoleType).IsRequired().HasColumnType("varchar(16)").HasConversion<string>();
                entity.Property(e => e.DateOfBirth);
                entity.Property(e => e.NationalId);
                entity.Property(e => e.Country).HasColumnType("varchar(32)").HasConversion<string>().HasDefaultValue(Countries.VN);
                entity.Property(e => e.Role).IsRequired().HasColumnType("varchar(16)").HasConversion<string>();
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
                entity.Property(e => e.ShipType).IsRequired().HasColumnType("varchar(16)").HasConversion<string>().HasDefaultValue(ShipType.Other);
                entity.Property(e => e.Length).IsRequired().HasColumnType("varchar(128)");
                entity.Property(e => e.ImagePath).HasColumnType("varchar(128)");
                entity.Property(e => e.Position);
                entity.Property(e => e.ShipStatus).IsRequired().HasColumnType("varchar(16)").HasConversion<string>().HasDefaultValue(ShipStatus.Docked);
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
                  .WithMany()
                  .HasForeignKey(e => e.OwnerId);
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

            modelBuilder.Entity<ShipCertificate>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().HasColumnType("bigint").HasDefaultValueSql("generate_id()");
                entity.Property(e => e.CertificateName).IsRequired().HasColumnType("varchar(128)");
                entity.Property(e => e.CertificateNo).IsRequired();
                entity.Property(e => e.CertificateStatus).IsRequired().HasColumnType("varchar(64)").HasConversion<string>().HasDefaultValue(CertificateStatus.None);
                entity.Property(e => e.ShipId).IsRequired();
                entity.Property(e => e.IssueDate).HasConversion<DateTime>();
                entity.Property(e => e.ExpiryDate).HasConversion<DateTime>();
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.CertificateName).IsUnique();
                entity.HasIndex(e => e.CertificateNo).IsUnique();
                entity.HasOne(e => e.Ship)
                .WithOne()
                .HasForeignKey<ShipCertificate>(e => e.ShipId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
            });
            modelBuilder.Entity<Crew>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().HasColumnType("bigint").HasDefaultValueSql("generate_id()");
                entity.Property(e => e.Fullname).IsRequired().HasColumnType("varchar(128)");
                entity.Property(e => e.NationalId).IsRequired();
                entity.Property(e => e.YearExperience).IsRequired();
                entity.Property(e => e.RelativePhoneNumber).IsRequired();
                entity.Property(e => e.Countries).IsRequired().HasColumnType("varchar(128)").HasConversion<string>().HasDefaultValue(Countries.VN);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
                entity.Property(e => e.CreatedBy).HasColumnType("bigint");
                entity.Property(e => e.UpdatedBy).HasColumnType("bigint");
                entity.HasIndex(e => e.NationalId).IsUnique();
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
            }
            );
            modelBuilder.Entity<CrewTrip>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().HasColumnType("bigint").HasDefaultValueSql("generate_id()");
                entity.Property(e => e.CrewId).HasColumnType("bigint");
                entity.Property(e => e.TripId).HasColumnType("varchar(128)");
                entity.Ignore(e => e.RegisterToDeparture);
                entity.Ignore(e => e.RegisterToArrival);
            });
            modelBuilder.Entity<ArrivalRegistration>(entity =>
            {
                entity.Ignore(e => e.Id);
                entity.Property(e => e.ArrivalId).IsRequired().HasColumnType("varchar(128)").HasDefaultValueSql("generate_arrival_id()");
                entity.Property(e => e.CaptainId).IsRequired().HasColumnType("bigint");
                entity.Property(e => e.ShipId).IsRequired().HasColumnType("bigint");
                entity.Property(e => e.ArrivalTime).HasConversion<DateTime>();
                entity.Property(e => e.ActualArrivalTime).HasConversion<DateTime>();
                entity.Property(e => e.Attachment).HasColumnType("varchar(256)");
                entity.Property(e => e.Note).HasColumnType("varchar(256)");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
                entity.Property(e => e.CreatedBy).IsRequired().HasColumnType("bigint");
                entity.Property(e => e.UpdatedBy).HasColumnType("bigint");
                entity.HasKey(e => e.ArrivalId);
                entity
                  .HasOne(e => e.Ship)
                  .WithMany()
                  .HasForeignKey(e => e.ShipId);
                entity.HasOne(e => e.Captain)
                    .WithMany()
                    .HasForeignKey(e => e.CaptainId);
                entity
                  .HasOne(e => e.Creator)
                  .WithMany()
                  .HasForeignKey(e => e.CreatedBy)
                  .OnDelete(DeleteBehavior.SetNull);
                entity
                .HasOne(e => e.Port)
                .WithMany()
                .HasForeignKey(e => e.PortId);
                entity
                  .HasOne(e => e.Updater)
                  .WithMany()
                  .HasForeignKey(e => e.UpdatedBy)
                  .OnDelete(DeleteBehavior.SetNull);
                entity.HasQueryFilter(e => !e.Creator.IsDeleted && !e.Updater.IsDeleted);
            });
            modelBuilder.Entity<DepartureRegistration>(entity =>
            {
                entity.Ignore(e => e.Id);
                entity.Property(e => e.Attachment).HasColumnType("varchar(256)");
                entity.Property(e => e.DepartureId).IsRequired().HasColumnType("varchar(128)").HasDefaultValueSql("generate_departure_id()"); ;
                entity.Property(e => e.CaptainId).IsRequired().HasColumnType("bigint");
                entity.Property(e => e.ShipId).IsRequired().HasColumnType("bigint");
                entity.Property(e => e.DepartureTime).HasConversion<DateTime>();
                entity.Property(e => e.ActualDepartureTime).HasConversion<DateTime>();
                entity.Property(e => e.Attachment).HasColumnType("varchar(256)");
                entity.Property(e => e.Note).HasColumnType("varchar(256)");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
                entity.Property(e => e.CreatedBy).IsRequired().HasColumnType("bigint");
                entity.Property(e => e.UpdatedBy).HasColumnType("bigint");
                entity.HasKey(e => e.DepartureId);

                entity
                  .HasOne(e => e.Ship)
                  .WithMany()
                  .HasForeignKey(e => e.ShipId);
                entity
                    .HasOne(e => e.Port)
                    .WithMany()
                    .HasForeignKey(e => e.PortId);
                entity.HasOne(e => e.Captain)
                    .WithMany()
                    .HasForeignKey(e => e.CaptainId);
                entity.HasOne(e => e.Port)
                    .WithMany()
                    .HasForeignKey(e => e.PortId);
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
                entity.HasQueryFilter(e => !e.Creator.IsDeleted && !e.Updater.IsDeleted);
            });
            modelBuilder.Entity<Port>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().HasColumnType("bigint").HasDefaultValueSql("generate_id()");
                entity.Property(e => e.Name).IsRequired().HasColumnType("varchar(128)");
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