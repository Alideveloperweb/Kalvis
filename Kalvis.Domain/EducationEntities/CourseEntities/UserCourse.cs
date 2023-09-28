
using Kalvis.Domain.UserEntities;

namespace Kalvis.Domain.EducationEntities.CourseEntities
{
    public class UserCourse
    {
        #region Properties
        public long UcId { get; private set; }
        public long UserId { get; private set; }
        public long CourseId { get; private set; }
        #endregion

        #region Create
        public UserCourse(long UcId, long UserId, long CourseId)
        {
            this.UcId = UcId;
            this.UserId = UserId;
            this.CourseId = CourseId;
        }
        #endregion

        #region Relation
        public Course Course { get; private set; }
        public User User { get; private set; }
        #endregion
    }
}
