using AutoMapper;
using GrowthDiary.IRepository;
using GrowthDiary.IService;
using GrowthDiary.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrowthDiary.Service
{
    public class UserService :IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task InsertOneAsync(UserViewModel viewModel)
        {
            var model = _mapper.Map<User>(viewModel);
            await _repository.InsertOneAsync(model);
        }
        public UserViewModel Find(UserSearchModel SearchModel)
        {
            var model = _repository.Find(SearchModel);
            return _mapper.Map<User, UserViewModel>(model);
        }

        public List<UserViewModel> FindAll()
        {
            var list = _repository.FindAll();
            return _mapper.Map<List<User>, List<UserViewModel>>(list);
        }

        public async Task<int> UpdateOneAsync(UserViewModel viewModel, params string[] fields)
        {
            var model = _mapper.Map<UserViewModel,User>(viewModel);
            return await _repository.UpdateOneAsync(model,fields);
        }
    }
}
