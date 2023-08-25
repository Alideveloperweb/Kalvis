using Kalvi.Domain.EducationEntities.CategoryEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.EFCore.Mapping.CategoryMapper
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreateDate);

            builder.Property(x => x.LastUpdate);

            builder.Property(x => x.IsRemove);

            builder.Property(x => x.EnCategoryName)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.FaCategoryName)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.HasMany(x => x.SubCategory)
                   .WithOne(x => x.Sub)
                   .HasForeignKey(x => x.SubId);

            builder.HasMany(x => x.ParentCategory)
                   .WithOne(x => x.Parent)
                   .HasForeignKey(x => x.ParentId);
        }
    }
}
