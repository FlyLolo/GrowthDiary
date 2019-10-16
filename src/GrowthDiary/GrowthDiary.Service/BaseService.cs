using GrowthDiary.IService;
using GrowthDiary.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrowthDiary.Service
{
    public class BaseService<T> : IBaseService<T> where T: BaseViewModel
    {
        public int Add(T model)
        {
            throw new NotImplementedException();
        }
    }
}
