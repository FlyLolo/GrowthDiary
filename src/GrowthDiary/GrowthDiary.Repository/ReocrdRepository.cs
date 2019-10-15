using GrowthDiary.IRepository;
using GrowthDiary.Model;

namespace GrowthDiary.Repository
{
    public class RecordRepository : BaseRepository<Record>, IRecordRepository
    {
        //public List<Record> GetList(RecordSearchInfo searchInfo)
        //{
        //    var builder = Builders<Record>.Filter;
        //    var filter = builder.Eq(m => m.State, searchInfo.State);
        //    var list = MongoHelper.FindList<Record>(filter);
        //    searchInfo.RecordCount = list.Count;
        //    return list.OrderByDescending(m => m.CreateTime).Skip(searchInfo.PageIndex * searchInfo.PageSize).Take(searchInfo.PageSize).ToList();
        //}
    }
}
