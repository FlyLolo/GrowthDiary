using GrowthDiary.ViewModel;

namespace GrowthDiary.IService
{
    public interface IBaseService<T> where T: BaseViewModel
    {
        int Add(T model);
    }
}
