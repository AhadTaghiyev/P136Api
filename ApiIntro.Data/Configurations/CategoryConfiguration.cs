using System;
using ApiIntro.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntro.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(20)
                .IsRequired(true)
                .IsUnicode(true);
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(x => x.CreatedAt)
                .HasDefaultValue(DateTime.UtcNow.AddHours(4));
        }
    }
}

