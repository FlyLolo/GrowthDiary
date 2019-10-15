using GrowthDiary.IRepository;
using GrowthDiary.Model;
using MongoDB.Driver;

namespace GrowthDiary.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public User Get(UserSearchInfo user)
        {
            var builder = Builders<User>.Filter;
            var filter = builder.Or(builder.Eq(m => m.UserCode, user.UserCode), builder.Eq(m => m.WxOpenId, user.WxOpenId));
            return MongoHelper.Find(filter);
        }
    }
}
