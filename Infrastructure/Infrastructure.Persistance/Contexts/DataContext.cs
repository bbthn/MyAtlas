

using Core.Domain.Entities;
using Core.Domain.Entities.Languages;
using Core.Domain.Entities.MyControllers;
using Core.Domain.Entities.Pages;
using Core.Domain.Entities.Url;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Infrastructure.Persistance.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions dbContextOptions):base(dbContextOptions) { }

        DbSet<Url> Urls { get; set; }
        DbSet<Page> Pages { get; set; }
        DbSet<MyController> MyControllers { get; set; }
        DbSet<Language> Languages { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in entries)
            {
                if(item.State == EntityState.Added)
                {
                    item.Entity.ModifiedDate = DateTime.Now;
                    item.Entity.CreatedDate = DateTime.Now;
                }
                else if(item.State == EntityState.Modified)
                {
                    item.Entity.ModifiedDate = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            foreach (var item in modelBuilder.Model.GetEntityTypes().SelectMany(i => i.GetForeignKeys()))
            {
                item.DeleteBehavior = DeleteBehavior.NoAction;

            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
