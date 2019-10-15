using GrowthDiary.ViewModel;

namespace GrowthDiary.IService
{
    public interface IUserService : IBaseService
    {
        int Add(UserViewModel user);
        UserViewModel Get(UserSearchViewModel SearchModel);
    }
}
