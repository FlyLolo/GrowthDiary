using GrowthDiary.Model;
using System.Collections.Generic;

namespace GrowthDiary.IRepository
{
    public interface IRecordRepository : IBaseRepository<Record>
    {
        List<Record> GetList(RecordSearchModel searchModel);
    }
}
