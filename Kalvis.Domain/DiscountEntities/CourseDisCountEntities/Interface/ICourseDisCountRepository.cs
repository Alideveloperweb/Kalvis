using Kalvis.Common.Domain;
using Kalvis.Contract.DisCountViewModel.CourseDisCountViewModel;

namespace Kalvis.Domain.DiscountEntities.CourseDisCountEntities.Interface
{

    public interface ICourseDisCountRepository
         : IRepositoryBase<int, CourseDisCount>
    {
        List<GetAllCourseDisCountItem> GetAllCourseDiscount(bool IsRemove);
        EditCourseDisCountItem FindDisCountForEdit(int DisCountId);

        GetDisCountItem GetDisCount(int DisCountID);
        GetDisCountItem GetDisCount(string DisCountCode);

    }
}