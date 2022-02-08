using ApiCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiCRUD.Context
{

    public class VehicleContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().ToTable("Vehicles");
            modelBuilder.Entity<Owner>().ToTable("Owners");
        }

    }
}
