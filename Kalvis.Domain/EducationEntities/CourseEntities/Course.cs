using Kalvi.Common.Domain;

using Kalvi.Domain.EducationEntities.CategoryEntities;
using Kalvi.Domain.EducationEntities.CommentEntities;

using System;
using System.Collections.Generic;

namespace Kalvi.Domain.EducationEntities.CourseEntities
{
    public class Course : EntityBase<long>
    {
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
        #endregion

        #region Relation
        public Category Category { get; private set; }
        //public User User { get; private set; }
        //public List<CourseEpisode> CourseEpisodes { get; private set; }
        //public List<CourseComment> CourseComments { get; private set; }
        //public List<UserCourse> UserCourses { get; private set; }
        //public List<CourseOrderDetails> CourseOrderDetails { get; private set; }
        #endregion

    }
}
