using GrowthDiary.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowthDiary.IService
{
    public interface IRecordService: IBaseService<RecordViewModel>
    {
        Task<List<RecordViewModel>> FindAsync(RecordSearchModel SearchModel);
    }
}
