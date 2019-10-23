using GrowthDiary.Common;
using GrowthDiary.IService;
using GrowthDiary.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrowthDiary.Controllers
{
    [Route("api/[controller]")]
    public class RecordController : BaseController
    {
        private readonly IRecordService _recordService;
        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet]
        public async Task<ApiResult> Get(RecordSearchModel searchViewModel)
        {
            try
            {
                var list = await _recordService.FindAsync(searchViewModel);
                return new ApiResult<PagesModel<RecordViewModel>>(new Model.PagesModel<RecordViewModel> { Items = list,PageSeting = searchViewModel.PageSeting});
            }
            catch (Exception ex)
            {
                return new ApiResult(ReturnCode.GeneralError);
            }
        }

        public async Task<ApiResult> Post([FromBody] RecordViewModel record)
        {
            if (record == null)
            {
                return new ApiResult(ReturnCode.ArgsError);
            }
            try
            {
                if (string.IsNullOrEmpty(record._id))
                {
                    await _recordService.InsertOneAsync(record);
                }
                else
                {
                    await _recordService.UpdateOneAsync(record);
                }

                return new ApiResult(ReturnCode.GeneralError);
            }
            catch (Exception)
            {
                return new ApiResult(ReturnCode.GeneralError);
            }            
        }
    }
}
