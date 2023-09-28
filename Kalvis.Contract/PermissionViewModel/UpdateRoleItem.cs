
namespace Kalvis.Contract.PermissionViewModel
{
    public class UpdateRoleItem
    {
        public int RoleID { get; set; }
        public string RoleTitle { get; set; }
        public List<int> PermissionID { get; set; }
    }
}
