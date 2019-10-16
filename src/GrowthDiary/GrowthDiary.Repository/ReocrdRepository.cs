using GrowthDiary.IRepository;
using GrowthDiary.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace GrowthDiary.Repository
{
    public class RecordRepository : BaseRepository<Record>, IRecordRepository
    {
        public List<Record> GetList(RecordSearchModel searchModel)
        {
            var builder = Builders<Record>.Filter;
            var filter = builder.Eq(m => m.State, searchModel.State);
            var list = MongoHelper.FindList<Record>(filter);
            searchModel.RecordCount = list.Count;
            return list.OrderByDescending(m => m.CreateTime).Skip(searchModel.PageIndex * searchModel.PageSize).Take(searchModel.PageSize).ToList();
        }
    }
}
