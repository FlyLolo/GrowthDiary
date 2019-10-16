using GrowthDiary.Model;

namespace GrowthDiary.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Get(UserSearchModel user);
    }
}
