using Kalvi.Domain.EducationEntities.CategoryEntities;
using Kalvis.EFCore.Mapping.CategoryMapper;
using Microsoft.EntityFrameworkCore;


namespace Kalvis.EFCore.ApplicationContexts
{
    public class ApplicationContext:DbContext
    {
        #region Constracture

        public ApplicationContext(DbContextOptions<ApplicationContext>options):base(options)
        {

        }

        #endregion

        #region Entity

        #region Category

        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        #endregion

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new SubCategoryMap());

            base.OnModelCreating(builder);
        }
        #endregion
    }
}
