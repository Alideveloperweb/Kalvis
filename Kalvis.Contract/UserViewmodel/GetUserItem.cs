﻿
namespace Kalvis.Contract.UserViewModel
{
    public class GetUserItem
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public long UserId { get; set; }
        public string Password { get; set; }
        public bool IsRemove { get; set; }
        public bool IsActive { get; set; }

    }
}
