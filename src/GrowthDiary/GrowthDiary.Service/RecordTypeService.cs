using AutoMapper;
using GrowthDiary.IRepository;
using GrowthDiary.IService;
using GrowthDiary.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowthDiary.Service
{
    public class RecordTypeService : IRecordTypeService
    {
        private readonly IRecordTypeRepository _repository;
        private readonly IMapper _mapper;
        public RecordTypeService(IRecordTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task InsertOneAsync(RecordTypeDefinitionViewModel viewModel)
        {
            var model = _mapper.Map<RecordTypeDefinition>(viewModel);
            await _repository.InsertOneAsync(model);
        }
        public async Task<List<RecordTypeDefinitionViewModel>> FindAllAsync()
        {
            var list = await _repository.FindAllAsync();
            return _mapper.Map<List<RecordTypeDefinition>, List<RecordTypeDefinitionViewModel>>(list);
        }

        #region 本例中未用方法，未实现
        public Task<int> UpdateOneAsync(RecordTypeDefinitionViewModel viewModel, params string[] fields)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
