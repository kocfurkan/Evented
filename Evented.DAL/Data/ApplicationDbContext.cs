using Evented.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Evented.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        DbSet<Image> Images { get; set; }
        DbSet<ImageGallery> ImageGalleries { get; set; }
        DbSet<Event> Event { get; set; }
        DbSet<Company> Company { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Configure multiple relation between User And Event
            builder.Entity<Event>().HasOne(e => e.CreatorUser).WithMany(x => x.UserCreated).HasForeignKey(y => y.CreatorId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<UserEvent>().HasKey(key => new { key.EventId, key.UserId });
            builder.Entity<UserEvent>().HasOne(ky => ky.User).WithMany(key => key.EventsJoined).HasForeignKey(key => key.UserId);
            builder.Entity<UserEvent>().HasOne(ky => ky.Event).WithMany(key => key.UsersJoined).HasForeignKey(key => key.EventId);
            builder.Entity<Event>().HasMany(e => e.Comments).WithOne(z => z.Event).HasForeignKey(x => x.EventId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Company>().HasMany(e => e.Notifications).WithOne(x => x.Company).HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Company>().HasOne(e => e.ImageGallery).WithOne(x => x.Company).HasForeignKey<ImageGallery>(id => id.CompanyId);
            builder.Entity<Company>().HasOne(e=>e.OwnedBy).WithMany(x=>x.Companies).HasForeignKey(key=>key.OwnedById);
            builder.Entity<Event>().HasOne(e => e.ImageGallery).WithOne(x => x.Event).HasForeignKey<ImageGallery>(id => id.EventId);
            builder.Entity<Notification>().HasOne(e=>e.User).WithMany(x=>x.Notifications).HasForeignKey(key=>key.UserId);
            builder.Entity<Event>().HasOne(e=>e.HiredCompany).WithMany(e=>e.Events).HasForeignKey(key=>key.HiredCompanyId);

            base.OnModelCreating(builder);

            this.SeedUsers(builder);
            this.SeedRoles(builder);
            this.SeedUserRoles(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            User user = new User()
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                AccessFailedCount = 0,
                ConcurrencyStamp = "295770ce-3f4b-4677-b0af-8d200fb60b8f",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                SecurityStamp = "a43230f0-c9b2-406b-ab50-cd0905055fd1",
                PasswordHash = passwordHasher.HashPassword(null, "1234Aa-"),
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = true,
                Address = "x",
                Birth = DateTime.Parse("2023-01-01"),
                CreatedAt = DateTime.Parse("2023-01-01"),
                FirstName = "Furkan",
                LastName = "Koc",
                Image = "X",
            };
            User user2 = new User()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e6",
                AccessFailedCount = 0,
                ConcurrencyStamp = "295770ce-3f4b-4677-b0af-8d200fb60b87",
                UserName = "user@user.com",
                NormalizedUserName = "USER@USER.COM",
                Email = "user@user.com",
                SecurityStamp = "a43230f0-c9b2-406b-ab50-cd0905055fd9",
                PasswordHash = passwordHasher.HashPassword(null, "1234Aa-"),
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = true,
                Address = "x",
                Birth = DateTime.Parse("2023-01-01"),
                CreatedAt = DateTime.Parse("2023-01-01"),
                FirstName = "Furkan",
                LastName = "Koc",
                Image = "X",
            };


            builder.Entity<User>().HasData(user, user2);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                new IdentityUserRole<string>() { RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330", UserId = "b74ddd14-6340-4840-95c2-db12554843e6" }
                );
        }

    }
}