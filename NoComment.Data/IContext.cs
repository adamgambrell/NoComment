using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoComment.Domain.Models;

namespace NoComment.Data
{
    public interface IContext : IDisposable
    {
        DbSet<Email> Emails { get; set; }
        DbSet<Forum> Forums { get; set; }

        string ProviderName { get; }
        void Migrate();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}