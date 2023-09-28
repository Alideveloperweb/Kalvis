using Kalvis.Common.Application;
using Kalvis.Contract.DisCount.CourseDisCountViewModel.Interface;
using Kalvis.Contract.DisCountViewModel.CourseDisCountViewModel;
using Kalvis.Domain.DiscountEntities.CourseDisCountEntities;
using Kalvis.Domain.DiscountEntities.CourseDisCountEntities.Interface;
using System;
using System.Collections.Generic;

namespace Kalvis.Application.DisCount
{
    public class CourseDisCountApplication
         : ICourseDisCountApplication
    {
        #region Constracture
        private readonly ICourseDisCountRepository _CourseDisRep;

        public CourseDisCountApplication(ICourseDisCountRepository CourseDisRep)
        {
            this._CourseDisRep = CourseDisRep;
        }
        #endregion



        public OperationResult CreateCourseDisCount(CreateCourseDisCountItem Dicount)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("تخفیف");

            if (_CourseDisRep.Exist(x => x.Code == Dicount.Code))
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("کد"));

            CourseDisCount courseDisCount = new(Dicount.Code,
                Dicount.StartDate.ShamsiToMiladi(), Dicount.EndDate.ShamsiToMiladi(), Dicount.Value,
                Dicount.MaxUserCount);

            bool Create = _CourseDisRep.Create(courseDisCount);
            if (!Create)
                return operationResult.Failed(Operation.Error, message.ErrorCreate());

            bool Save = _CourseDisRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Create());
        }

        public EditCourseDisCountItem FindDisCountForEdit(int DisCountId)
        {
            return _CourseDisRep.FindDisCountForEdit(DisCountId);
        }

        public List<GetAllCourseDisCountItem> GetAllCourseDiscount(bool IsRemove)
        {
            return _CourseDisRep.GetAllCourseDiscount(IsRemove);
        }

        public OperationResult EditCourseDisCount(EditCourseDisCountItem Dicount)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("تخفیف");

            if (_CourseDisRep.Exist(x =>
            x.Id != Dicount.CourseDisCountID &&
            x.Code == Dicount.Code))
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("کد"));

            CourseDisCount courseDisCount = _CourseDisRep.Get(Dicount.CourseDisCountID);

            if (courseDisCount == null)
                return operationResult.Failed(Operation.Nullabel, message.Nullabele());

            courseDisCount.Edit(Dicount.Code,
                Dicount.StartDate.ShamsiToMiladi(), Dicount.EndDate.ShamsiToMiladi(), Dicount.Value,
                Dicount.MaxUserCount);

            bool Update = _CourseDisRep.Update(courseDisCount);
            if (!Update)
                return operationResult.Failed(Operation.Error, message.ErrorUpdate());

            bool Save = _CourseDisRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Update());
        }

        public DisCountOrderItem DisCountOrder(DisCountOrderItem DisCountOrder)
        {
            DisCountOrderItem OperationDisCount = new();

            var DisCount = _CourseDisRep.GetDisCount(DisCountOrder.DisCountCode);

            if (DisCount == null)
            {
                OperationDisCount.Status = false;
                OperationDisCount.Message = "کد تخفیف نا معتبر است.";
                return OperationDisCount;
            }

            if (string.IsNullOrEmpty(DisCount.StartDate.ToString())
                && DisCount.StartDate.ShamsiToMiladi() > DateTime.Now.Date)
            {
                OperationDisCount.Status = false;
                OperationDisCount.Message = "کد تخفیف نا معتبر است.";
                return OperationDisCount;
            }

            if (string.IsNullOrEmpty(DisCount.EndDate.ToString())
                  && DisCount.EndDate.ShamsiToMiladi() > DateTime.Now.Date)
            {
                OperationDisCount.Status = false;
                OperationDisCount.Message = "کد تخفیف نا معتبر است.";
                return OperationDisCount;
            }

            if (DisCount.UserCount <= 0 && DisCount.UserCount != null)
            {
                OperationDisCount.Status = false;
                OperationDisCount.Message = "کد تخفیف به اتمام رسیده است.";
                return OperationDisCount;
            }

            OperationDisCount.DisCountCode = DisCount.DisCountCode;
            OperationDisCount.Message = "کد تخفیف با موفقیت اعمال شد";
            OperationDisCount.Price = DisCount.Persistant;
            OperationDisCount.Status = true;
            OperationDisCount.DisCountID = DisCount.DisCountID;
            return OperationDisCount;

        }
    }
}
