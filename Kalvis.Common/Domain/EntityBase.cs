using System;
using System.ComponentModel.DataAnnotations;

namespace Kalvi.Common.Domain
{
    public class EntityBase<Tkey>
    {
        public Tkey Id { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? LastUpdate { get; set; }
        public bool IsRemove { get; set; }

        #region Constracture

        public EntityBase()
        {
            CreateDate = DateTime.Now;
            IsRemove = false;
        }
        #endregion


    }

}
