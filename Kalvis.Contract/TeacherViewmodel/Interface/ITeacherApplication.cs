using Kalvis.Common.Application;

namespace Kalvis.Contract.TeacherViewModel.Interface
{
    public interface ITeacherApplication
    {
        List<GetAllTeacherItem> GetAllTeacher();
        OperationResult AddUserForTeacher(UserUpgradeItem userUpgrade);
        UserUpgradeItem FindTeacherById(long TeacherId);


    }
}
