using Microsoft.EntityFrameworkCore;

namespace TrailerTicketSystem.Data
{
    public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<State> States => Set<State>();
        public DbSet<Trailer> Trailers => Set<Trailer>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<AppUser> Users => Set<AppUser>();


        protected override void OnModelCreating(ModelBuilder b)
        {
            // ===== state =====
            b.Entity<State>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).ValueGeneratedNever();
                e.Property(x => x.Name).HasMaxLength(64).IsRequired();
            });

            // ===== trailer =====
            b.Entity<Trailer>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).ValueGeneratedNever();
                e.Property(x => x.LicensePlate).HasMaxLength(15).IsRequired();
                e.Property(x => x.StateId).IsRequired();

                e.HasOne(x => x.State)
                 .WithMany(s => s.Trailers)
                 .HasForeignKey(x => x.StateId)
                 .OnDelete(DeleteBehavior.NoAction)
                 .IsRequired();

                e.HasIndex(x => x.LicensePlate).IsUnique();
            });

            // ===== app_user =====
            b.Entity<AppUser>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).HasMaxLength(64).IsRequired();
                e.Property(x => x.Password).HasMaxLength(255).IsRequired();
            });

            // ===== ticket =====
            b.Entity<Ticket>(e =>
            {
                // composite primary key
                e.HasKey(x => new { x.TrailerId, x.ReportedAt });

                e.Property(x => x.ReportNote).HasMaxLength(255).IsRequired();
                e.Property(x => x.FixNote).HasMaxLength(255);

                e.HasOne(x => x.Trailer)
                 .WithMany(t => t.Tickets)
                 .HasForeignKey(x => x.TrailerId)
                 .OnDelete(DeleteBehavior.NoAction)
                 .IsRequired();

                e.HasOne(x => x.Author)
                 .WithMany(u => u.TicketsAuthored)
                 .HasForeignKey(x => x.AuthorId)
                 .OnDelete(DeleteBehavior.NoAction)
                 .IsRequired();

                e.HasOne(x => x.Mechanic)
                 .WithMany(u => u.TicketsRepaired)
                 .HasForeignKey(x => x.MechanicId)
                 .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
