using GrowthDiary.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowthDiary.IRepository
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        T FindById(string id);

        List<T> FindAll();
        Task<List<T>> FindAllAsync();

        void InsertOne(T info);
        Task InsertOneAsync(T info);

        int UpdateOne(T info, params string[] fields);
        Task<int> UpdateOneAsync(T info, params string[] fields);

        int ReplaceOne(T info);
        Task<int> ReplaceOneAsync(T info);
    }
}
