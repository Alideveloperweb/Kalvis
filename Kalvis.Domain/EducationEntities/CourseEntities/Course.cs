using Kalvis.Common.Domain;
using Kalvis.Common.Enum;
using Kalvis.Domain.EducationEntities.CategoryEntities;
using Kalvis.Domain.EducationEntities.CommentEntities;
using Kalvis.Domain.OrderEntities.CourseOrderEntities;
using Kalvis.Domain.UserEntities;

namespace Kalvis.Domain.EducationEntities.CourseEntities
{
    public class Course : EntityBase<long>
    {
        private CourseLevel courseLevel;
        private Language language;
        private string imageName;
        private int courseCategoryId;
        public Language Language;
        #region Properties
        public string CourseTitle { get; private set; }
        public string CourseSummery { get; private set; }
        public int CoursePrice { get; private set; }
        //public CourseLevel CourseLevel { get; private set; }
        //public Language Language { get; private set; }
        public string CourseImage { get; private set; }
        public string CourseDescription { get; private set; }
        public string Tags { get; private set; }
        public bool ActiveComment { get; private set; }
        public bool ActiveFaq { get; private set; }
        public int CategoryId { get; private set; }
        public long UserId { get; private set; }
        public byte Percentage { get; private set; }
        #endregion

        #region Create
        public Course(string CourseTitle, string CourseSummery,
            int CoursePrice,/* CourseLevel CourseLevel, Language Language,*/
            string CourseImage, string CourseDescription, string Tags,
            bool ActiveComment, bool ActiveFaq, int CategoryId
            , long UserId, byte Percentage)
        {
            this.CourseTitle = CourseTitle;
            this.CourseSummery = CourseSummery;
            this.CoursePrice = CoursePrice;
            //this.CourseLevel = CourseLevel;
            //this.Language = Language;
            this.CourseImage = CourseImage;
            this.CourseDescription = CourseDescription;
            this.Tags = Tags;
            this.ActiveComment = ActiveComment;
            this.ActiveFaq = ActiveFaq;
            this.CategoryId = CategoryId;
            this.UserId = UserId;
            this.Percentage = Percentage;
        }

        public Course(string courseTitle, string courseSummery, int coursePrice, CourseLevel courseLevel, Language language, string imageName, string courseDescription, string tags, bool activeComment, bool activeFaq, int courseCategoryId, long userId, byte percentage)
        {
            CourseTitle = courseTitle;
            CourseSummery = courseSummery;
            CoursePrice = coursePrice;
            this.courseLevel = courseLevel;
            this.language = language;
            this.imageName = imageName;
            CourseDescription = courseDescription;
            Tags = tags;
            ActiveComment = activeComment;
            ActiveFaq = activeFaq;
            this.courseCategoryId = courseCategoryId;
            UserId = userId;
            Percentage = percentage;
        }

        #endregion

        #region Edit
        public void Edit(string CourseTitle, string CourseSummery,
             int CoursePrice,/* CourseLevel CourseLevel, Language Language,*/
             string CourseImage, string CourseDescription, string Tags,
             bool ActiveComment, bool ActiveFaq, int CategoryId
                , long UserId, byte Percentage)
        {
            this.CourseTitle = CourseTitle;
            this.CourseSummery = CourseSummery;
            this.CoursePrice = CoursePrice;
            //this.CourseLevel = CourseLevel;
            //this.Language = Language;
            this.CourseImage = CourseImage;
            this.CourseDescription = CourseDescription;
            this.Tags = Tags;
            this.ActiveComment = ActiveComment;
            this.ActiveFaq = ActiveFaq;
            this.CategoryId = CategoryId;
            this.UserId = UserId;
            this.Percentage = Percentage;
            this.LastUpdate = DateTime.Now;
        }
        #endregion

        #region Remove
        public void Remove()
        {
            this.IsRemove = true;
        }
        #endregion

        #region Restore
        public void Restore()
        {
            this.IsRemove = false;
        }

        public void Edit(string courseTitle, string courseSummery, int coursePrice, CourseLevel courseLevel, Language language, string imageName, string courseDescription, string tags, bool activeComment, bool activeFaq, int courseCategoryId, long userId, byte percentage)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Relation
        public Category Category { get; private set; }
        public User User { get; private set; }
        public List<CourseEpisode> CourseEpisodes { get; private set; }
        public List<CourseComment> CourseComments { get; private set; }
        public List<UserCourse> UserCourses { get; private set; }
        public List<CourseOrderDetails> CourseOrderDetails { get; private set; }
        public CourseLevel CourseLevel { get; set; }
        #endregion

    }
}
