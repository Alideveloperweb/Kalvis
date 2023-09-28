using Kalvis.Common.Application;

using Kalvis.Contract.CourseViewModel;
using Kalvis.Contract.CourseViewModel.Interface;
using Kalvis.Domain.EducationEntities.CategoryEntities.Interface;
using Kalvis.Domain.EducationEntities.CourseEntities;
using Kalvis.Domain.EducationEntities.CourseEntities.Interface;

namespace Kalvis.Application.CourseApp
{
    public class CourseApplication : ICourseApplication
    {

        #region Constracture
        private readonly ICourseRepository _courseRep;
        private readonly ICategoryRepository _CategoryRep;
        public CourseApplication(ICourseRepository courseRep,
            ICategoryRepository CategoryRep)
        {
            this._courseRep = courseRep;
            this._CategoryRep = CategoryRep;
        }
        #endregion

        public OperationResult CreateCourse(CreateCourseItem createCourseItem)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("دوره");

            if (_courseRep.Exist(x => x.CourseTitle == createCourseItem.CourseTitle))
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("عنوان"));

            string CategoryName = _CategoryRep.FindNameCategoryById(createCourseItem.CourseCategoryId);
            string ImageName = createCourseItem.Uploder.Uplode(Router.RouteImageEducation + CategoryName);
            if (String.IsNullOrEmpty(ImageName))
                return operationResult.Failed(Operation.ErrorUplod, message.ErrorUplodeImage());

            Course course = new (createCourseItem.CourseTitle,
                createCourseItem.CourseSummery, createCourseItem.CoursePrice,
                createCourseItem.courseLevel, createCourseItem.Language,
                ImageName, createCourseItem.CourseDescription, createCourseItem.Tags,
                createCourseItem.ActiveComment, createCourseItem.ActiveFaq,
                createCourseItem.CourseCategoryId, createCourseItem.UserId,
                createCourseItem.Percentage);

            bool Create = _courseRep.Create(course);
            if (!Create)
                return operationResult.Failed(Operation.Error, message.ErrorCreate());

            bool Save = _courseRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Create());

        }

        public EditCourseItem FindCourseForEdit(long CourseId)
        {
            return _courseRep.FindCourseForEdit(CourseId);
        }

        public List<GetAllCourseItem> getAllCourse(bool IsRemove)
        {
            return _courseRep.getAllCourse(IsRemove);
        }

        public OperationResult EditCourse(EditCourseItem EditCourse)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("دوره");

            if (_courseRep.Exist(x =>
            x.Id != EditCourse.CourseId &&
            x.CourseTitle == EditCourse.CourseTitle))
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("عنوان"));
            Course course = _courseRep.Get(EditCourse.CourseId);

            string ImageName = EditCourse.Uploder != null ? ""
                : course.CourseImage;


            string CategoryName = _CategoryRep.FindNameCategoryById(EditCourse.CourseCategoryId);
            if (EditCourse.Uploder != null)
            {

                course.CourseImage.RemoveFile(Router.RouteImageEducation + CategoryName);
                ImageName = EditCourse.Uploder.Uplode(Router.RouteImageEducation + CategoryName);
                if (String.IsNullOrEmpty(ImageName))
                    return operationResult.Failed(Operation.ErrorUplod, message.ErrorUplodeImage());
            }

            if (EditCourse.CourseCategoryId != course.CategoryId)
            {
                string OldRoute = _CategoryRep.FindNameCategoryById(course.CategoryId);
                Uploder.MoveFile(Router.RouteImageEducation + CategoryName,
                    Router.RouteImageEducation + OldRoute, course.CourseImage);
            }


            course.Edit(EditCourse.CourseTitle,
                EditCourse.CourseSummery, EditCourse.CoursePrice,
                EditCourse.courseLevel, EditCourse.Language,
                ImageName, EditCourse.CourseDescription, EditCourse.Tags,
                EditCourse.ActiveComment, EditCourse.ActiveFaq,
                EditCourse.CourseCategoryId, EditCourse.UserId,
                EditCourse.Percentage);

            bool Update = _courseRep.Update(course);
            if (!Update)
                return operationResult.Failed(Operation.Error, message.ErrorUpdate());

            bool Save = _courseRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Update());

        }

        public RemoveCourseItem FindCourseForRemove(long CourseId)
        {
            return _courseRep.FindCourseForRemove(CourseId);
        }

        public OperationResult RemoveCourse(RemoveCourseItem RemoveCourse)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("دوره");

            Course course = _courseRep.Get(RemoveCourse.CourseId);

            if (course == null)
                return operationResult.Failed(Operation.Nullabel, message.Nullabele());

            course.Remove();

            bool Update = _courseRep.Update(course);
            if (!Update)
                return operationResult.Failed(Operation.Error, message.ErrorUpdate());

            bool Save = _courseRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Remove());

        }

        public List<GetAllCourseQueryITem> GetAllCourseQuery(bool IsRemove)
        {
            return _courseRep.GetAllCourseQuery(IsRemove);
        }

        public GetCourseQueryItem GetCourseQuery(long CourseID)
        {
            return _courseRep.GetCourseQuery(CourseID);

        }

        public List<SimilarQueryItem> ListSimilar(int CategoryID, long CourseID)
        {
            return _courseRep.ListSimilar(CategoryID, CourseID);
        }

        public bool Buyer(long UserID, long CourseID)
        {
            return _courseRep.Buyer(UserID, CourseID);
        }

    }
}
