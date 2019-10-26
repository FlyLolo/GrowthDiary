using System.Collections.Generic;

namespace GrowthDiary.Model
{
    public class UserViewModel:BaseViewModel
    {
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string WxOpenId { get; set; }
        public string NickName { get; set; }
        public string AvatarUrl { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Language { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }
        public int State { get; set; }

        public UserPermissions UserPermissions { get; set; }
    }

    public class UserPermissions
    {
        public string UserCode { get; set; }
        public List<Role> Roles { get; set; }
        public List<Permission> Permissions { get; set; }
    }

    public class Permission
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public string Method { get; set; }
    }

    public class Role
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
