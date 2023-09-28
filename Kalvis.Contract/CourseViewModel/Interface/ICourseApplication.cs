using Kalvis.Contract.CourseViewModel;
using Kalvis.Common.Application;

namespace Kalvis.Contract.CourseViewModel.Interface
{
    public interface ICourseApplication
    {
        List<GetAllCourseItem> getAllCourse(bool IsRemove);
        OperationResult CreateCourse(CreateCourseItem createCourseItem);
        EditCourseItem FindCourseForEdit(long CourseId);
        OperationResult EditCourse(EditCourseItem EditCourse);
        RemoveCourseItem FindCourseForRemove(long CourseId);
        OperationResult RemoveCourse(RemoveCourseItem RemoveCourse);
        List<GetAllCourseQueryITem> GetAllCourseQuery(bool IsRemove);
        GetCourseQueryItem GetCourseQuery(long CourseID);
        List<SimilarQueryItem> ListSimilar(int CategoryID, long CourseID);
        bool Buyer(long UserID, long CourseID);
    }
}
