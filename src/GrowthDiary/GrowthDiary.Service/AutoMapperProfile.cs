using AutoMapper;
using GrowthDiary.Model;

namespace GrowthDiary.Service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();

            CreateMap<RecordViewModel, Record>();
            CreateMap<Record, RecordViewModel>();
        }
    }
}
