using GrowthDiary.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowthDiary.IRepository
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        T GetById(string id) ;
        List<T> GetList();
        int Add(T info);
        int Update(T info, params string[] fields);
        Task<int> UpdateAsync(T info, params string[] fields);
        Task<int> ReplaceOneAsync(T info);
        int ReplaceOne(T info);
    }
}
