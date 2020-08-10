using CardPro.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardPro.Data.Configurations
{
    public class CriteriaConfiguration : IEntityTypeConfiguration<Criteria>
    {
        public void Configure(EntityTypeBuilder<Criteria> builder)
        {
            builder.ToTable("Criteria");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CardTypeId).IsRequired();
            builder.Property(x => x.MinimumIncome).IsRequired();
            builder.Property(x => x.MinimumAge).IsRequired();
        }
    }
}