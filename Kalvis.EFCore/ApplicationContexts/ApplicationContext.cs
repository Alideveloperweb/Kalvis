using Kalvi.Domain.EducationEntities.CategoryEntities;
using Kalvi.Domain.EducationEntities.CommentEntities;
using Kalvi.Domain.EducationEntities.CourseEntities;
using Kalvis.Domain.EducationEntities.UserEntities;
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

        #region User 

        public DbSet<User> users{ get; set; }

        #endregion

        #region Course

        public DbSet<Course> courses { get; set; }

        public DbSet<CourseEpisode> CourseEpisodes { get; set; }

        public DbSet<CourseComment> CourseComments { get; set; }

        public DbSet<AnswerComment> AnswerComments { get; set; }

        public DbSet<UserCourse> UserCourses { get; set; }

        #endregion

        #region Orders
        public DbSet<CourseOrders> CourseOrders { get; set; }
        public DbSet<CourseOrderDetails> CourseOrderDetails { get; set; }
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
