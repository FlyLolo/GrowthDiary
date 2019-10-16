using GrowthDiary.ViewModel;

namespace GrowthDiary.IService
{
    public interface IUserService : IBaseService<UserViewModel>
    {
        UserViewModel Find(UserSearchViewModel SearchModel);
    }
}
