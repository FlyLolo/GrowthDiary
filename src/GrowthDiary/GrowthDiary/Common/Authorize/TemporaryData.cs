using System.Collections.Generic;
using System.Linq;
using GrowthDiary.Model;

namespace FlyLolo.JWT.API
{
    /// <summary>
    /// 此处为虚拟数据，模拟从数据库或缓存中读取用户相关的权限。实际项目根据项目的大小等可能会采用不同粒度的权限管理方式。
    /// </summary>
    public static class TemporaryData
    {
        public readonly static List<UserPermissions> UserPermissions = new List<UserPermissions> {
            new UserPermissions {
                UserCode = "001",
                Roles = new List<Role> {
                    new Role { Code = "System.Manager", Name = "系统管理"},
                    new Role { Code = "Record.Viewer", Name = "记录浏览" },
                    new Role { Code = "Record.Operator", Name = "记录操作"}
                },
                Permissions = new List<Permission> {
                    new Permission { Code = "User.Write", Name = "用户管理", Url = "/api/user",Method="post"},
                    new Permission { Code = "Record.Read", Name = "记录读取", Url = "/api/record",Method="get" },
                    new Permission { Code = "Record.Write", Name = "记录修改", Url = "/api/record",Method="post"}
                }
            },
            new UserPermissions {
                UserCode = "002",
                Roles = new List<Role> {
                    new Role { Code = "Record.Viewer", Name = "记录浏览" }
                },
                Permissions = new List<Permission> {
                    new Permission { Code = "Record.Read", Name = "记录读取", Url = "/api/record",Method="get" }
                }
            },
        };

        public static UserPermissions GetUserPermission(string userCode)
        {
            return UserPermissions.FirstOrDefault(m => m.UserCode.Equals(userCode));
        }
    }


}
