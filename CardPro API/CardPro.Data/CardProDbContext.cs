using CardPro.Data.Configurations;
using CardPro.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardPro.Data
{
    public class CardProDbContext : DbContext
    {
        public DbSet<Bank> Banks { get; set; }

        public DbSet<CardType> CardTypes { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Criteria> Criterias { get; set; }

        public CardProDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BankConfiguration());
            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.ApplyConfiguration(new CardTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CriteriaConfiguration());
        }
    }
}