using Kalvis.Common.Domain;
using Kalvis.Domain.BlogEntities;
using Kalvis.Domain.EducationEntities.CourseEntities;

namespace Kalvis.Domain.EducationEntities.CategoryEntities
{
    public class Category : EntityBase<int>
    {
        public string EnCategoryName { get; private set; }
        public string FaCategoryName { get; private set; }

        #region Create

        public Category(string EnCategoryName,string FaCategoryName)
        {
            this.EnCategoryName = EnCategoryName;
            this.FaCategoryName = FaCategoryName;
        }
      
        #endregion

        #region Edit
        public void Edit(string EnCategoryName,
             string FaCategoryName)
        {
            this.EnCategoryName = EnCategoryName;
            this.FaCategoryName = FaCategoryName;
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

        public List<SubCategory> SubCategory { get;  set; }
        public List<SubCategory> ParentCategory { get; private set; }
        public long ParentId { get; set; }

        public static implicit operator Category(bool v)
        {
            throw new NotImplementedException();
        }
        public List<Course> Courses { get; private set; }
        public List<Blog> Blogs { get; private set; }

        #endregion

    }
}
