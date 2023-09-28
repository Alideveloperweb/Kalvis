
namespace Kalvis.Contract.TeacherViewModel
{
    public class GetAllTeacherItem
    {
        public long TeacherId { get; set; }
        public string UserName { get; set; }
        public string CreateDate { get; set; }
        public int Wallet { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemove { get; set; }
    }
}
