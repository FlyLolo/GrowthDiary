using GrowthDiary.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowthDiary.IService
{
    public interface IRecordTypeService: IBaseService<RecordTypeDefinitionViewModel>
    {
        Task<List<RecordTypeDefinitionViewModel>> FindAllAsync();
    }
}
