using GrowthDiary.Common;
using GrowthDiary.IService;
using GrowthDiary.Model;
using Microsoft.AspNetCore.Mvc;
using SharpCompress.Writers;
using System;
using System.Collections.Generic;
using System.IO;
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
                return new ApiResult<PagesModel<RecordViewModel>>(new Model.PagesModel<RecordViewModel> (list,searchViewModel));
            }
            catch (Exception)
            {
                return new ApiResult(ReturnCode.GeneralError);
            }
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody]RecordViewModel record)
        {
            if (record == null)
            {
                return new ApiResult(ReturnCode.ArgsError);
            }
            try
            {
                if (string.IsNullOrEmpty(record._id) && record.State == 1)
                {
                    record.CreateTime = DateTime.Now;
                    await _recordService.InsertOneAsync(record);
                }
                else if (!string.IsNullOrEmpty(record._id) && record.State == 2)
                {
                    await _recordService.UpdateOneAsync(record,"State");
                }
            }
            catch (Exception)
            {
                return new ApiResult(ReturnCode.GeneralError);
            }
            return new ApiResult(ReturnCode.Success);
        }
    }
}
