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


            //Configure multiple relation between User And Event
            builder.Entity<Event>().HasOne(e => e.CreatorUser).WithMany(x => x.UserCreated).HasForeignKey(y => y.CreatorId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Event>().HasMany(e => e.UserJoined).WithMany(y => y.EventJoined);
            builder.Entity<Event>().HasMany(e => e.Comments).WithOne(z => z.Event).HasForeignKey(x => x.EventId).OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);

            this.SeedUsers(builder);
            this.SeedUserRoles(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            User user = new User()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                AccessFailedCount = 0,
                ConcurrencyStamp = "295770ce-3f4b-4677-b0af-8d200fb60b8f",
                UserName = "myadmin",
                NormalizedUserName = "MYADMIN",
                SecurityStamp = "a43230f0-c9b2-406b-ab50-cd0905055fd1",
                PasswordHash = passwordHasher.HashPassword(null, "Admin*123"),
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = true,
                Address = "x",
                Birth = DateTime.Now,
                CreatedAt = DateTime.Now,
                FirstName = "Furkan",
                LastName = "Koc",
                Image = "X",
            };
            User user2 = new User()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e6",
                AccessFailedCount = 0,
                ConcurrencyStamp = "295770ce-3f4b-4677-b0af-8d200fb60b87",
                UserName = "user",
                NormalizedUserName = "MYUSER",
                SecurityStamp = "a43230f0-c9b2-406b-ab50-cd0905055fd9",
                PasswordHash = passwordHasher.HashPassword(null, "Admin*123"),
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = true,
                Address = "x",
                Birth = DateTime.Now,
                CreatedAt = DateTime.Now,
                FirstName = "Furkan",
                LastName = "Koc",
                Image = "X",
            };



        builder.Entity<User>().HasData(user,user2);
    }

    private void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
            new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" },
            new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7335", Name = "Company", ConcurrencyStamp = "3", NormalizedName = "COMPANY" }
            );
    }

    private void SeedUserRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },
            new IdentityUserRole<string>() { RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330", UserId = "b74ddd14-6340-4840-95c2-db12554843e6" }
            );






        //builder.Entity<User>().HasData(new IdentityRole
        //{
        //    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
        //    Name = "Administrator",
        //    NormalizedName = "ADMINISTRATOR".ToUpper()
        //});

        //builder.Entity<User>().HasData(new IdentityRole
        //{
        //    Id = "2c5e174e-3b0e-446f-86af-483d56fd7215",
        //    Name = "User",
        //    NormalizedName = "USER".ToUpper()
        //    ,
        //});
        //builder.Entity<User>().HasData(new IdentityRole
        //{
        //    Id = "2c5e174e-3b0e-446f-86af-483d56fd7216",
        //    Name = "Company",
        //    NormalizedName = "COMPANY".ToUpper()
        //});

        //var hasher = new PasswordHasher<User>();

        ////Seeding the User to AspNetUsers table
        //builder.Entity<User>().HasData(
        //    new User
        //    {
        //        Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
        //        AccessFailedCount = 0,
        //        ConcurrencyStamp = "295770ce-3f4b-4677-b0af-8d200fb60b8f",
        //        UserName = "myadmin",
        //        NormalizedUserName = "MYADMIN",
        //        SecurityStamp = "a43230f0-c9b2-406b-ab50-cd0905055fd1",
        //        PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
        //        EmailConfirmed = true,
        //        LockoutEnabled = false,
        //        TwoFactorEnabled = false,
        //        PhoneNumberConfirmed = true,
        //        Address = "x",
        //        Birth = DateTime.Now,
        //        CreatedAt = DateTime.Now,
        //        FirstName = "Furkan",
        //        LastName = "Koc",
        //        Image = "X",

        //    }
        //);
        //builder.Entity<User>().HasData(
        //    new User
        //    {
        //        Id = "8e445865-a24d-4543-a6c6-9443d048cdb0", // primary key
        //        AccessFailedCount = 0,
        //        ConcurrencyStamp = "c9c3828e-9b86-4e80-8e4e-adce0b9066f5",
        //        UserName = "myuser",
        //        NormalizedUserName = "MYUSER",
        //        PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
        //        EmailConfirmed = true,
        //        SecurityStamp = "528f44bd-6885-4d4d-9539-5a7c4849c273",
        //        LockoutEnabled = false,
        //        TwoFactorEnabled = false,
        //        PhoneNumberConfirmed = true,
        //        Address= "x",
        //        Birth=DateTime.Now,
        //        CreatedAt=DateTime.Now,
        //        FirstName="Furkan",
        //        LastName="Koc",
        //        Image="X",

        //    }
        //);
        //  builder.Entity<Company>().HasData(
        //    new User
        //    {
        //        Id = "8e445865-a24d-4543-a6c6-9443d048cdb1", // primary key
        //            UserName = "mycompany",
        //        NormalizedUserName = "MYCOMPANY",
        //        PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
        //        EmailConfirmed = true,
        //        AccessFailedCount = 0,
        //        LockoutEnabled = false,
        //        TwoFactorEnabled = false,
        //        PhoneNumberConfirmed = true,
        //    }
        //);

        //Create Connection between user and role
        // builder.Entity<IdentityUserRole<string>>().HasData(
        // new IdentityUserRole<string>
        // {
        //     RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
        //     UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
        // });
        // builder.Entity<IdentityUserRole<string>>().HasData(
        //new IdentityUserRole<string>
        //{
        //    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7215",
        //    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb0"
        //});
        //    builder.Entity<IdentityUserRole<string>>().HasData(
        //new IdentityUserRole<string>
        //{
        //    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7216",
        //    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb1"
        //});


    }
}
}