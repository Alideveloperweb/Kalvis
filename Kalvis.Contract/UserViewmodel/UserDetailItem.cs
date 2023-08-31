using Microsoft.AspNetCore.Http;


namespace Kalvis.Contract.UserViewmodel
{
    public class UserDetailItem
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserImage { get; set; }
        public IFormFile Uploder { get; set; }

    }
}
