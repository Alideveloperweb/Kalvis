

using Kalvis.Common.Domain;
using Kalvis.Contract.TeacherViewModel;

namespace Kalvis.Domain.EducationEntities.TeacherEntities.Interface
{
    public interface ITeacherRepository : IRepositoryBase<int, Teacher>
    {
        List<GetAllTeacherItem> GetAllTeacher();
        UserUpgradeItem FindTeacherById(long TeacherId);
        List<GetTeacherForCommitionItem> getTeacherForCommition(List<long> TeacherID);
    }
}
