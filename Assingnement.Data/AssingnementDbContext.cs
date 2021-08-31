using Assingnement.Core.Enum;
using Assingnement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Data
{
    public class AssingnementDbContext : DbContext
    {
        public AssingnementDbContext(DbContextOptions<AssingnementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Owner>()
                .HasMany(e => e.Cars)
                .WithOne(p => p.Owner)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Brand>()
                .HasMany(e => e.Models)
                .WithOne(p => p.Brand)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Model>()
                .HasMany(e => e.Cars)
                .WithOne(p => p.Model)
                .OnDelete(DeleteBehavior.Restrict);

            DeliveryKingDbContextInitializer.Seed(ref builder);

            base.OnModelCreating(builder);
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
    }
}
