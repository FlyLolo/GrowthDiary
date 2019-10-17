using GrowthDiary.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowthDiary.IService
{
    public interface IBaseService<T> where T: BaseViewModel
    {
        Task InsertOneAsync(T viewModel);
        Task<int> UpdateOneAsync(T viewModel, params string[] fields);
    }
}
