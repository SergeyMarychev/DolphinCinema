using DolphinCinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DolphinCinema.Domain
{
    public class DolphinCinemaDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<PermissionGroup> PermissionGroups { get; set; }
        public DbSet<Promo> Promos { get; set; }
        public DbSet<Event> Events { get; set; }
		public DbSet<Slider> Sliders { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        public DolphinCinemaDbContext(DbContextOptions options) : base(options)
        {
			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieGenre>().HasKey(mg => new {mg.MovieId, mg.GenreId});
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieId);
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.GenreId);

            modelBuilder.Entity<RolePermission>().HasKey(mg => new { mg.RoleId, mg.PermissionId });
            modelBuilder.Entity<RolePermission>()
                .HasOne(mg => mg.Role)
                .WithMany(m => m.RolePermissions)
                .HasForeignKey(mg => mg.RoleId);
            modelBuilder.Entity<RolePermission>()
                .HasOne(mg => mg.Permission)
                .WithMany(m => m.RolePermissions)
                .HasForeignKey(mg => mg.PermissionId);
        }
    }
}
