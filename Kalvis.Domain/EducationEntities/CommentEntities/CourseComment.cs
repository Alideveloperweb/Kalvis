
using Kalvi.Common.Domain;
using Kalvi.Domain.EducationEntities.CourseEntities;

using System;
using System.Collections.Generic;

namespace Kalvi.Domain.EducationEntities.CommentEntities
{
    public class CourseComment : EntityBase<long>
    {
        #region Properties
        public long UserId { get; private set; }
        public string CommentText { get; private set; }
        public long CourseId { get; private set; }
        public bool IsActive { get; private set; }

        #endregion

        #region Create
        public CourseComment(long UserId, string CommentText,
            long CourseId)
        {
            this.UserId = UserId;
            this.CommentText = CommentText;
            this.CourseId = CourseId;
            this.IsActive = false;
        }
        #endregion

        #region Edit
        public void Edit(string CommentText, bool IsActive)
        {
            this.CommentText = CommentText;
            this.IsActive = IsActive;
            this.LastUpdate = DateTime.Now;
        }
        #endregion

        #region Accept
        public void Accept()
        {
            this.IsActive = true;
        }
        #endregion

        #region Relation
        public Course Course { get; private set; }
        //public User User { get; private set; }
        //public List<AnswerComment> AnswerComments { get; private set; }
        #endregion
    }
}
