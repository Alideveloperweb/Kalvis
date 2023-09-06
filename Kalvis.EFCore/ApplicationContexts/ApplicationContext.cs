using Kalvi.Domain.EducationEntities.CategoryEntities;
using Kalvi.Domain.EducationEntities.CommentEntities;
using Kalvi.Domain.EducationEntities.CourseEntities;
using Kalvi.Domain.EducationEntities.TeacherEntities;
using Kalvis.Domain.BlogEntities;
using Kalvis.Domain.DiscountEntities.CourseDisCountEntities;
using Kalvis.Domain.EducationEntities.UserEntities;
using Kalvis.Domain.NotificationEntities;
using Kalvis.Domain.OrderEntities.CourseOrderEntities;
using Kalvis.Domain.PermissionEntities;
using Kalvis.Domain.TicketEntities;
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
        
        public DbSet<User> users { get; set; }
        
        public DbSet<Teacher> Teachers { get; set; }
        
        #endregion
        
        #region Course
        
        public DbSet<Course> courses { get; set; }
        
        public DbSet<CourseEpisode> CourseEpisodes { get; set; }
        
        public DbSet<CourseComment> CourseComments { get; set; }
        
        public DbSet<AnswerComment> AnswerComments { get; set; }
        
        public DbSet<UserCourse> UserCourses { get; set; }
        
        #endregion
        
        #region Blog
        
        public DbSet<Blog> Blogs { get; set; }
        
        #endregion
        
        #region DisCount
        
        public DbSet<CourseDisCount> CourseDisCounts { get; set; }
        
        #endregion
        
        #region Orders
        
        public DbSet<CourseOrders> CourseOrders { get; set; }
        
        public DbSet<CourseOrderDetails> CourseOrderDetails { get; set; }
        
        #endregion
        
        #region Notification
        
        public DbSet<Notification> Notifications { get; set; }
        
        #endregion
        
        #region Ticket
        
        public DbSet<Ticket> Tickets { get; set; }
        
        public DbSet<TicketAnswer> TicketAnswers { get; set; }
        
        #endregion
        
        #region Permission
        
        public DbSet<Role> Roles { get; set; }
        
        public DbSet<RolePermission> RolePermissions { get; set; }
        
        public DbSet<UserRole> userRoles { get; set; }
        
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
