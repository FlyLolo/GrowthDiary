using GrowthDiary.IRepository;
using GrowthDiary.IService;
using GrowthDiary.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrowthDiary.Service
{
    public class UserService :BaseService<UserViewModel>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserViewModel Find(UserSearchViewModel SearchModel)
        {
            throw new NotImplementedException();
        }
    }
}
