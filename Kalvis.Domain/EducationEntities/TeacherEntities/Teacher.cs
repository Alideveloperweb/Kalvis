using Kalvi.Domain.EducationEntities.CourseEntities;

using System.Collections.Generic;

namespace Kalvi.Domain.EducationEntities.TeacherEntities
{
    public class Teacher
    {
        public int Id { get; private set; }

        public long TeacherId { get; private set; }

        #region Create
        public Teacher(int Id, long TeacherId)
        {
            this.Id = Id;
            this.TeacherId = TeacherId;
        }
        #endregion


        #region Relation
        //public User user { get; private set; }
        #endregion

    }
}
