using GrowthDiary.Common;
using GrowthDiary.IService;
using GrowthDiary.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrowthDiary.Controllers
{
    [Route("api/[controller]")]
    public class RecordTypeController : BaseController
    {
        private readonly IRecordTypeService _recordTypeService;
        public RecordTypeController(IRecordTypeService recordTypeService)
        {
            _recordTypeService = recordTypeService;
        }

        [HttpGet]
        public async Task<ApiResult> Get()
        {
            try
            {
                var list = await _recordTypeService.FindAllAsync();
                return new ApiResult<List<RecordTypeDefinitionViewModel>>(list);
            }
            catch (System.Exception)
            {
                return new ApiResult(ReturnCode.GeneralError);
            }

        }

        public ApiResult Post([FromBody] RecordTypeDefinitionViewModel record)
        {
            try
            {
                _recordTypeService.InsertOneAsync(record);
                return new ApiResult(ReturnCode.Success);
            }
            catch (System.Exception)
            {
                return new ApiResult(ReturnCode.GeneralError);
            }
        }
    }
}
