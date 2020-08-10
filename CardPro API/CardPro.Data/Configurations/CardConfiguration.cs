using CardPro.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardPro.Data.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Card");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CardTypeId).IsRequired();
            builder.Property(x => x.BankId).IsRequired();
            builder.Property(x => x.CardNumber).IsRequired();
            builder.Property(x => x.NameOnCard).IsRequired();
            builder.Property(x => x.cvv).IsRequired();
            builder.Property(x => x.PIN).IsRequired();
        }
    }
}