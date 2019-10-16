using AutoMapper;
using GrowthDiary.IService;
using GrowthDiary.Model;
using GrowthDiary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowthDiary.Service
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserViewModel,User>();
            CreateMap<User, UserViewModel>();
        }
    }
}
