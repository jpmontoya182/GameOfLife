using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Game = Infrastructure.Models.Game;

namespace Infrastructure.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable(nameof(Game));
        }
    }
}
