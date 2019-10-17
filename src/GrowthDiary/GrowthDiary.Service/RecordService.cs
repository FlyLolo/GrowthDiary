using AutoMapper;
using GrowthDiary.IRepository;
using GrowthDiary.IService;
using GrowthDiary.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowthDiary.Service
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;
        private readonly IMapper _mapper;
        public RecordService(IRecordRepository RecordRepository, IMapper mapper)
        {
            _recordRepository = RecordRepository;
            _mapper = mapper;
        }

        public async Task InsertOneAsync(RecordViewModel viewModel)
        {
            var model = _mapper.Map<Record>(viewModel);
            model.CreateTime = DateTime.Now;
            await _recordRepository.InsertOneAsync(model);
        }

        public async Task<List<RecordViewModel>> FindAsync(RecordSearchModel searchModel)
        {
            var list = await _recordRepository.FindAllAsync(searchModel);
            return  _mapper.Map<List<Record>, List<RecordViewModel>>(list);
        }

        public async Task<int> UpdateOneAsync(RecordViewModel viewModel, params string[] fields)
        {
            var model = _mapper.Map<Record>(viewModel);
            return await _recordRepository.UpdateOneAsync(model, fields);
        }
    }
}
