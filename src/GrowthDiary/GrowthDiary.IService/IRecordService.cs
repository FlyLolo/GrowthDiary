using GrowthDiary.ViewModel;
using System.Collections.Generic;

namespace GrowthDiary.IService
{
    public interface IRecordService: IBaseService<RecordViewModel>
    {
        List<RecordViewModel> Find(RecordSearchViewModel SearchModel);
    }
}
