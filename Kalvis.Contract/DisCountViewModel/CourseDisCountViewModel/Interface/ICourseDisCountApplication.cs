using Kalvis.Common.Application;
using Kalvis.Contract.DisCountViewModel.CourseDisCountViewModel;

namespace Kalvis.Contract.DisCount.CourseDisCountViewModel.Interface
{
    public interface ICourseDisCountApplication

    {
        List<GetAllCourseDisCountItem> GetAllCourseDiscount(bool IsRemove);
        OperationResult CreateCourseDisCount(CreateCourseDisCountItem Dicount);
        EditCourseDisCountItem FindDisCountForEdit(int DisCountId);
        OperationResult EditCourseDisCount(EditCourseDisCountItem Dicount);
        DisCountOrderItem DisCountOrder(DisCountOrderItem DisCountOrder);
    }
}
