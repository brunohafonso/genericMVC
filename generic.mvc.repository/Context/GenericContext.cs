using System.Linq;
using Microsoft.EntityFrameworkCore;
using generic.mvc.domain.Entities;

namespace generic.mvc.repository.Context
{
    public class GenericContext : DbContext 
    {
        public GenericContext(DbContextOptions<GenericContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating (modelBuilder);
        }
    }
}