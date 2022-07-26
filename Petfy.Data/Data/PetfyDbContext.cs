﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Petfy.Data.Models;

namespace Petfy.Data
{
    public class PetfyDbContext : IdentityDbContext<
        AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, 
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        //Agrego la entidad photo sin agregar como dbSet porque esta dentro de pet y porque esta mapeado
        public DbSet<Pet> Pets { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Vaccine> Vaccines { get; set; }

        //public DbSet<AppUser> Users { get; set; } Ya se implementa con el identity

        //public DbSet<PetVaccine> PetVaccines { get; set; }


        //public PetfyDbContext(DbContextOptions<PetfyDbContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Petfy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Owner>()
            //    .Property(x => x.City)
            //    .IsRequired(false);

            //modelBuilder.Entity<Owner>().HasData(
            //        new Owner { ID = 1, Name = "Default", Address = "Address 123", DateOfBirth = DateTime.Parse("2000-01-10") });

            //modelBuilder.Entity<Pet>()
            //    .Property(x => x.Name)
            //    .HasMaxLength(50);

            //modelBuilder.Entity<PetVaccine>()
            //    .HasKey(x => new { x.PetID, x.VaccineID });

            //modelBuilder.Entity<Vaccine>().HasData(
            //       new Vaccine { ID = 1, Name = "Vaccine Demo", Lab = "Lab Demo" });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .IsRequired();

            modelBuilder.Entity<AppRole>()
                .HasMany(u => u.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .IsRequired();


        }
    }
}
