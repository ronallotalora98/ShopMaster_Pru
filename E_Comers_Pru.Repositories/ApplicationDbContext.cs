using E_Comers_Pru.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Repositories
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> User { get; set; }
        public DbSet<RolEntity> Rol { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<OrdenEntity> Orden { get; set; }
        public DbSet<DetailOrderEntity> DetailOrder { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<OfferEntity> Offer { get; set; }
        public DbSet<OfferTypeEntity> OfferType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
