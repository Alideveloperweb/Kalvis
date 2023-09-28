using Kalvis.Common.Application;
using Kalvis.Contract.TeacherViewModel;
using Kalvis.Contract.TeacherViewModel.Interface;
using Kalvis.Domain.EducationEntities.TeacherEntities;
using Kalvis.Domain.EducationEntities.TeacherEntities.Interface;
using System.Collections.Generic;

namespace Kalvis.Application.TeacherApp
{
    public class TeacherApplication : ITeacherApplication
    {

        #region Constracture
        private readonly ITeacherRepository _TeacherRep;
        public TeacherApplication(ITeacherRepository TeacherRep)
        {
            this._TeacherRep = TeacherRep;
        }
        #endregion

        public OperationResult AddUserForTeacher(UserUpgradeItem userUpgrade)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("مدرس");

            UserUpgradeItem teacher =
                _TeacherRep.FindTeacherById(userUpgrade.TeacherId);

            if (teacher == null && userUpgrade.IsTeacher)
            {
                Teacher Th = new(0, userUpgrade.TeacherId);
                bool Create = _TeacherRep.Create(Th);
                if (!Create)
                    return operationResult.Failed(Operation.Error, message.ErrorCreate());

                bool Save = _TeacherRep.SaveChanges();
                if (!Save)
                    return operationResult.Failed(Operation.Error, message.ErrorSave());
                return operationResult.Success(Operation.Success, message.Create());

            }
            else if (teacher != null && !userUpgrade.IsTeacher)
            {
                Teacher Th = new(teacher.Id, teacher.TeacherId);
                bool Remove = _TeacherRep.Remove(Th);
                if (!Remove)
                    return operationResult.Failed(Operation.Error, message.ErrorRemove());

                bool Save = _TeacherRep.SaveChanges();
                if (!Save)
                    return operationResult.Failed(Operation.Error, message.ErrorSave());

                return operationResult.Success(Operation.Success, message.Remove());

            }
            return operationResult.Success(Operation.Success, message.Update());

        }

        public UserUpgradeItem FindTeacherById(long TeacherId)
        {
            return _TeacherRep.FindTeacherById(TeacherId);
        }

        public List<GetAllTeacherItem> GetAllTeacher()
        {
            return _TeacherRep.GetAllTeacher();
        }
    }
}
