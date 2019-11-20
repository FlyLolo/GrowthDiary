using GrowthDiary.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowthDiary.IRepository
{
    public interface IRecordRepository : IBaseRepository<Record>
    {
        Task<List<Record>> FindAllAsync(RecordSearchModel searchModel);
    }
}
