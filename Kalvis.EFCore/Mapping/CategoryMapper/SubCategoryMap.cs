using Kalvi.Domain.EducationEntities.CategoryEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.EFCore.Mapping.CategoryMapper
{
    public class SubCategoryMap : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.ToTable("SubCategories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ParentId)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.SubId)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.HasOne(u => u.Sub)
                   .WithMany(x => x.SubCategory)
                   .HasForeignKey(x => x.SubId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Parent)
                   .WithMany(x => x.ParentCategory)
                   .HasForeignKey(x => x.ParentId);
        }
    }
}
