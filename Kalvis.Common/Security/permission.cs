
namespace Kalvis.Common.Security
{
    public class permission
    {
        public string PermissionTile { get; set; }
        public int PermissionID { get; set; }
        public int? PermissionParent { get; set; }

        public List<permission> GetAllPermission()
        {
            List<permission> permissions = new()
            {
                new permission { PermissionID = CheackPermission.DashbordAdmin, PermissionParent = null, PermissionTile = "داشبورد ادمین" },
                new permission { PermissionID = CheackPermission.GetAllCourse, PermissionParent = null, PermissionTile = "نمایش دوره ها" },
                new permission { PermissionID = CheackPermission.CreateCourse, PermissionParent = CheackPermission.GetAllCourse, PermissionTile = "ثبت دوره" },
                new permission { PermissionID = CheackPermission.EditCourse, PermissionParent = CheackPermission.GetAllCourse, PermissionTile = "ویرایش دوره" },

            };
            return permissions;
        }

    }
}
