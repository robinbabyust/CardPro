using CardPro.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardPro.Data.Configurations
{
    public class CardTypeConfiguration : IEntityTypeConfiguration<CardType>
    {
        public void Configure(EntityTypeBuilder<CardType> builder)
        {
            builder.ToTable("CardType");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.BankId).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Category).IsRequired();
            builder.Property(x => x.CreditLimit).IsRequired();
            builder.Property(x => x.CashLimit).IsRequired();
        }
    }
}