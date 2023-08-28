
namespace Kalvi.Domain.EducationEntities.CategoryEntities
{
    public class SubCategory
    {
        public int Id { get; private set; }

        public int ParentId { get; private set; }
        public int SubId { get; set; }


        #region Constractore
        public SubCategory(int Id, int ParentId, int SubId)
        {
            this.Id = Id;
            this.ParentId = ParentId;
            this.SubId = SubId;
        }
        #endregion

        #region Relation

        public Category Parent { get;  set; }
        public Category Sub { get; set; }

        #endregion

    }
}
