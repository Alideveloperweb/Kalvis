using Kalvis.Common.Application;
using Kalvis.Contract.DisCountViewModel.CourseDisCountViewModel;
using Kalvis.Domain.DiscountEntities.CourseDisCountEntities;
using Kalvis.Domain.DiscountEntities.CourseDisCountEntities.Interface;
using Kalvis.EFCore.ApplicationContexts;


namespace Kalvis.EfCore.Repository.DisCount
{
    public class CourseDisCountRepository: RepositoryBase<int, CourseDisCount>, ICourseDisCountRepository
    {

        #region Constracture

        private readonly ApplicationContext _context;
        public CourseDisCountRepository(ApplicationContext context)
       : base(context)
        {
            this._context = context;
        }

        #endregion
        
        public EditCourseDisCountItem FindDisCountForEdit(int DisCountId)
        {
            return _context.CourseDisCounts
                 .Where(x => x.Id == DisCountId)
                 .Select(x => new EditCourseDisCountItem
                 {
                     Code = x.Code,
                     CourseDisCountID = x.Id,
                     EndDate = x.EndtDate.MiladiToShamsi(),
                     MaxUserCount = x.MaxUserCount,
                     StartDate = x.StartDate.MiladiToShamsi(),
                     Value = x.Value,
                 })
                 .FirstOrDefault();

        }

        public List<GetAllCourseDisCountItem> GetAllCourseDiscount(bool IsRemove)
        {
            return _context.CourseDisCounts
                .Where(x => x.IsRemove == IsRemove)
                .Select(x => new GetAllCourseDisCountItem
                {
                    Code = x.Code,
                    CourseDisCountID = x.Id,
                    EndDate = ConvertDate.MiladiToShamsi(x.EndtDate),
                    MaxUserCount = x.MaxUserCount,
                    StartDate = ConvertDate.MiladiToShamsi(x.StartDate),
                    Value = x.Value,

                }).ToList();
        }

        public GetDisCountItem GetDisCount(int DisCountID)
        {
            return _context.CourseDisCounts
                .Where(x => x.Id == DisCountID)
                .Select(x => new GetDisCountItem
                {
                    DisCountCode = x.Code,
                    DisCountID = x.Id,
                    EndDate = x.EndtDate.MiladiToShamsi(),
                    Persistant = x.Value,
                    StartDate = x.StartDate.MiladiToShamsi(),
                    UserCount = x.MaxUserCount,

                }).FirstOrDefault();
        }

        public GetDisCountItem GetDisCount(string DisCountCode)
        {
            return _context.CourseDisCounts
             .Where(x => x.Code == DisCountCode)
             .Select(x => new GetDisCountItem
             {
                 DisCountCode = x.Code,
                 DisCountID = x.Id,
                 EndDate = x.EndtDate.MiladiToShamsi(),
                 Persistant = x.Value,
                 StartDate = x.StartDate.MiladiToShamsi(),
                 UserCount = x.MaxUserCount,

             }).FirstOrDefault();
        }
    }
}
