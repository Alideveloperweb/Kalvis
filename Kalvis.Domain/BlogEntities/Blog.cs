using Kalvis.Domain.EducationEntities.CategoryEntities;
using Kalvis.Common.Domain;

namespace Kalvis.Domain.BlogEntities
{

    public class Blog : EntityBase<int>
    {
        #region Properties
        public string BlogTitle { get; private set; }
        public string BlogImage { get; private set; }
        public int CategoryId { get; private set; }
        public string BlogDescription { get; private set; }
        public string Tags { get; private set; }
        public bool IsComment { get; private set; }
        public bool IsActive { get; private set; }
        #endregion

        #region Create
        public Blog(string BlogTitle, string BlogImage,
            int CategoryId, string BlogDescription, string Tags,
            bool IsComment, bool IsActive)
        {
            this.BlogTitle = BlogTitle;
            this.BlogImage = BlogImage;
            this.CategoryId = CategoryId;
            this.BlogDescription = BlogDescription;
            this.Tags = Tags;
            this.IsComment = IsComment;
            this.IsActive = IsActive;
        }
        #endregion

        #region Edit
        public void Edit(string BlogTitle, string BlogImage,
            int CategoryId, string BlogDescription, string Tags,
            bool IsComment, bool IsActive)
        {
            this.BlogTitle = BlogTitle;
            this.BlogImage = BlogImage;
            this.CategoryId = CategoryId;
            this.BlogDescription = BlogDescription;
            this.Tags = Tags;
            this.IsComment = IsComment;
            this.IsActive = IsActive;
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
        public Category category { get;  set; }
        #endregion
    }
}
