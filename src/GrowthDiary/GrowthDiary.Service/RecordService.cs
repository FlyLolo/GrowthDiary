using AutoMapper;
using GrowthDiary.IRepository;
using GrowthDiary.IService;
using GrowthDiary.Model;
using GrowthDiary.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrowthDiary.Service
{
    public class RecordService :BaseService<RecordViewModel>, IRecordService
    {
        private readonly IRecordRepository _recordRepository;
        private readonly IMapper _mapper;
        public RecordService(IRecordRepository RecordRepository, IMapper mapper)
        {
            _recordRepository = RecordRepository;
            _mapper = mapper;
        }
        public List<RecordViewModel> Find(RecordSearchViewModel searchViewModel)
        {
            var searchModel = _mapper.Map<RecordSearchViewModel, RecordSearchModel>(searchViewModel);
            var list = _recordRepository.GetList(searchModel);
            _ = _mapper.Map<RecordSearchModel,RecordSearchViewModel>(searchModel);
            return _mapper.Map<List<Record>,List<RecordViewModel>>(list);
        }
    }
}
