using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoComment.Domain.Models;

namespace NoComment.Data {
    public class NoCommentContext : DbContext //, IContext 
    {
        public NoCommentContext (DbContextOptions<NoCommentContext> options) : base (options) { }
        
        // public DbSet<Forum> Forums { get; set; }
        // public DbSet<Email> Emails { get; set; }

        public string ProviderName => base.Database.ProviderName;
        public void Migrate () {
            Database.Migrate ();
        }
        public Task<int> SaveChangesAsync () {
            return base.SaveChangesAsync ();
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            // modelBuilder.Entity<Forum> ()
            //     .HasKey (t => new { t.RootEmailId });
            // modelBuilder.Entity<Email> ()
            //     .HasKey (e => new { e.MessageId });
        }
    }
}