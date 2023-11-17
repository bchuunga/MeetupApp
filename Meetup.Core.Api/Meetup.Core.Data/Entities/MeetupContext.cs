using Microsoft.EntityFrameworkCore;

namespace Meetup.Core.Data.Entities
{
    public class MeetupContext : DbContext
    {
        public MeetupContext(DbContextOptions<MeetupContext> options) : base(options)
        {
            
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Lecture> Lectures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meetup>()
                .HasOne(c => c.CreatedBy);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role);

            modelBuilder.Entity<Meetup>()
                .HasOne(m => m.Location)
                .WithOne(l => l.Meetup)
                .HasForeignKey<Location>(l => l.MeetupId);

            modelBuilder.Entity<Meetup>()
                .HasMany(m => m.Lectures)
                .WithOne(l => l.Meetup);

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    RoleName = "Admin",
                },
                new Role
                {
                    Id = 2,
                    RoleName = "Moderator",
                },
                new Role
                {
                    Id = 3,
                    RoleName = "User",
                }
                );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "admin@email.com",
                    FirstName = "admin",
                    LastName = "admin",
                    Nationality = "American",
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    RoleId = 1,
                    PasswordHash = "pass1"
                },
                new User
                {
                    Id = 2,
                    Email = "moderator@email.com",
                    FirstName = "moderator",
                    LastName = "moderator",
                    Nationality = "American",
                    DateOfBirth = DateTime.Now.AddYears(-10),
                    RoleId = 2,
                    PasswordHash = "pass1"
                },
                new User
                {
                    Id = 3,
                    Email = "user@email.com",
                    FirstName = "user",
                    LastName = "user",
                    Nationality = "American",
                    DateOfBirth = DateTime.Now.AddYears(-55),
                    RoleId = 3,
                    PasswordHash = "pass1"
                }
                );

            modelBuilder.Entity<Meetup>().HasData(
                new Meetup
                {
                    Id = 1,
                    Name = "Angular 17",
                    Organizer = "Google",
                    Date = DateTime.Now.AddDays(10),
                    IsPrivate = true,
                    CreatedById = 1,

                },
                new Meetup
                {
                    Id = 2,
                    Name = ".NET 8",
                    Organizer = "Microsoft",
                    Date = DateTime.Now.AddDays(-110),
                    IsPrivate = false,
                    CreatedById = 2,

                },
                new Meetup
                {
                    Id = 3,
                    Name = "SQL",
                    Organizer = "Microsoft",
                    Date = DateTime.Now.AddDays(50),
                    IsPrivate = true,
                    CreatedById = 3,

                }
                );
        }

    }
}
