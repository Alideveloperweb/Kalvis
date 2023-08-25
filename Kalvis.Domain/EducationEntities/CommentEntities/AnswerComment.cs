
using Kalvi.Common.Domain;


namespace Kalvi.Domain.EducationEntities.CommentEntities
{
    public class AnswerComment : EntityBase<long>
    {
        public long UserID { get; private set; }
        public string AnswerText { get; private set; }
        public long CommentID { get; private set; }


        #region Create
        public AnswerComment(long UserID, string AnswerText, long CommentID)
        {
            this.UserID = UserID;
            this.AnswerText = AnswerText;
            this.CommentID = CommentID;
        }
        #endregion

        #region Relation
       // public User User { get; private set; }
        public CourseComment CourseComment { get; private set; }
        #endregion
    }
}
