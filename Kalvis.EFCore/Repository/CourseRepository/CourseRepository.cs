using Kalvis.Contract.CourseViewModel;
using Kalvis.Domain.EducationEntities.CourseEntities;
using Kalvis.Common.Application;
using Kalvis.Contract.CourseViewModel;
using Kalvis.EFCore.ApplicationContexts;
using Kalvis.Domain.EducationEntities.CourseEntities.Interface;
using Microsoft.EntityFrameworkCore;

namespace Kalvis.EFCore.Repository.CourseRepository
{

    public class CourseRepository : RepositoryBase<long, Course>,
        ICourseRepository
    {
        #region Constracture
        private readonly ApplicationContext _context;
        public CourseRepository(ApplicationContext context)
            : base(context)
        {
            this._context = context;
        }

        #endregion

        public bool Buyer(long UserID, long CourseID)
        {
            return _context.UserCourses.Any(x => x.UserId == UserID
            && x.CourseId == CourseID);
        }

        public EditCourseItem FindCourseForEdit(long CourseId)
        {
            return _context.courses
                 .Where(x => x.Id == CourseId)
                 .Select(x => new EditCourseItem
                 {
                     ActiveComment = x.ActiveComment,
                     ActiveFaq = x.ActiveFaq,
                     CourseCategoryId = x.CategoryId,
                     CourseDescription = x.CourseDescription,
                     CourseId = x.Id,
                     CourseImage = x.CourseImage,
                     courseLevel = x.CourseLevel,
                     CoursePrice = x.CoursePrice,
                     CourseSummery = x.CourseSummery,
                     CourseTitle = x.CourseTitle,
                     Language = x.Language,
                     Percentage = x.Percentage,
                     Tags = x.Tags,
                     UserId = x.UserId,

                 }).FirstOrDefault();
        }

        public RemoveCourseItem FindCourseForRemove(long CourseId)
        {
            return _context.courses
                 .Where(x => x.Id == CourseId)
                 .Select(x => new RemoveCourseItem
                 {
                     CourseId = x.Id,
                     CourseTitle = x.CourseTitle,

                 }).FirstOrDefault();
        }

        public List<GetAllCourseItem> getAllCourse(bool IsRemove)
        {
            return _context.courses
                .Where(x => x.IsRemove == IsRemove)
                .Select(x => new GetAllCourseItem
                {
                    CourseId = x.Id,
                    CourseImage =
                    Router.RouteImageEducation +
                    _context.Categories.FirstOrDefault(c => c.Id == x.CategoryId)
                    .EnCategoryName + "/" +
                    x.CourseImage,
                    CourseLevel = x.CourseLevel,
                    CoursePrice = x.CoursePrice,
                    CourseTitle = x.CourseTitle,

                })
                .OrderByDescending(x => x.CourseId)
                .ToList();
        }

        public List<GetAllCourseQueryITem> GetAllCourseQuery(bool IsRemove)
        {
            return _context.courses
                .Include(x => x.CourseEpisodes)
                .Include(x => x.Category)
                .Include(x => x.User)
                .Where(x => x.IsRemove == IsRemove)
                .Select(x => new GetAllCourseQueryITem
                {
                    CourseCategoryName = x.Category.FaCategoryName,
                    CourseID = x.Id,
                    CourseImage =
                    Router.RouteImageEducation +
                    x.Category.EnCategoryName + "/" + x.CourseImage,

                    CoursePrice = x.CoursePrice,
                    CourseTitle = x.CourseTitle,
                    EpisodeCount = x.CourseEpisodes.Count(),
                    TeacherImage = Router.RouteImageUser +
                   x.User.Avatar == null || x.User.Avatar == "" ? "" : x.User.Avatar,

                    TeacherName = x.User.FirstName + " " + x.User.LastName,
                    UserCourseCount = x.UserCourses.Count(),

                })
                .OrderByDescending(x => x.CourseID)
                .ToList();

        }

        public GetCourseQueryItem GetCourseQuery(long CourseID)
        {
            return _context.courses
                .Include(x => x.CourseEpisodes)
                .Include(x => x.Category)
                .Include(x => x.UserCourses)
                .Include(x => x.User)
                .Where(x => !x.IsRemove)
                .Where(x => x.Id == CourseID)
                .Select(x => new GetCourseQueryItem
                {
                    CategoryID = x.CategoryId,
                    CategoryNames = x.Category.FaCategoryName,
                    CourseDesCription = x.CourseDescription,
                    CourseID = x.Id,
                    CourseImage = Router.RouteImageEducation +
                    x.Category.EnCategoryName + "/" + x.CourseImage,

                    courseLevel = x.CourseLevel,
                    CoursePrice = x.CoursePrice,
                    CourseSummery = x.CourseSummery,
                    CourseTitle = x.CourseTitle,
                    Language = x.Language,
                    LastUpdate = x.LastUpdate.MiladiToShamsi(),
                    TeacherName = x.User.FirstName + " " + x.User.LastName,
                    UserCourseCount = x.UserCourses.Count(),
                    GetAllEpisode = x.CourseEpisodes
                    .Select(e => new GetAllEpisodeForCourse
                    {
                        EpisodeID = e.Id,
                        EpisodeLink = e.LinkEpisode,
                        EpisodeTime = e.EpisodeTime,
                        EpisodeTitle = e.EpisodeTitle,
                        IsFree = e.IsFree,
                    }).ToList(),

                })
                .FirstOrDefault();
            throw new System.NotImplementedException();
        }

        public List<SimilarQueryItem> ListSimilar(int CategoryID, long CourseID)
        {
            return _context.courses
                .Include(x => x.Category)
                .Include(x => x.UserCourses)
                .Include(x => x.User)
                .Where(x => !x.IsRemove)
                .Where(x => x.CategoryId == CategoryID)
                .Where(x => x.Id != CourseID)
                .Select(x => new SimilarQueryItem
                {
                    CategoryName = x.Category.FaCategoryName,
                    CourseID = x.Id,
                    CourseImage =
                    Router.RouteImageEducation +
                    x.Category.EnCategoryName + "/" + x.CourseImage,

                    CoursePrice = x.CoursePrice,
                    CourseTitle = x.CourseTitle,
                    EpisodeCount = x.CourseEpisodes.Count(),
                    // TeacherImage = Router.RouteImageUser +
                    //x.User.Avatar == null || x.User.Avatar == "" ? "" : x.User.Avatar,

                    TeacherName = x.User.FirstName + " " + x.User.LastName,
                    UserCourseCount = x.UserCourses.Count(),

                })
                .OrderBy(x => Guid.NewGuid())
                .Take(2)
                .ToList();

        }
    }
}
