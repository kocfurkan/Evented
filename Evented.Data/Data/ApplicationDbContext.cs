using Evented.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Evented.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Configure multiple relation between User And Event
            builder.Entity<Event>().HasOne(e => e.CreatorUser).WithMany(x => x.UserCreated).HasForeignKey(y => y.CreatorId);
            builder.Entity<Event>().HasMany(e => e.JoinedUsers).WithMany(y => y.UserJoined);

            //Seeding Roles Into DB On Creation
            builder.Entity<User>().HasData(new IdentityRole 
            { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", 
              Name = "Administrator",
              NormalizedName = "ADMINISTRATOR".ToUpper() });

            builder.Entity<User>().HasData(new IdentityRole
            {
                Id = "2c5e174e-3b0e-446f-86af-483d56fd7215",
                Name = "User",
                NormalizedName = "USER".ToUpper()
            });
            builder.Entity<User>().HasData(new IdentityRole
            {
                Id = "2c5e174e-3b0e-446f-86af-483d56fd7216",
                Name = "User",
                NormalizedName = "COMPANY".ToUpper()
            });


            var hasher = new PasswordHasher<User>();


            //Seeding the User to AspNetUsers table
            builder.Entity<User>().HasData(
                new User
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "myuser",
                    NormalizedUserName = "MYUSER",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                }
            );

            //Create Connection between user and role
            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            });

        }
    }
}