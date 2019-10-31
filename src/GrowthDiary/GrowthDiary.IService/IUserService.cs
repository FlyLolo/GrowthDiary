using GrowthDiary.Model;
using System.Collections.Generic;

namespace GrowthDiary.IService
{
    public interface IUserService : IBaseService<UserViewModel>
    {
        UserViewModel Find(UserSearchModel searchModel);
        List<UserViewModel> FindAll();
    }
}
