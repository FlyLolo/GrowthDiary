using GrowthDiary.Model.Base;

namespace GrowthDiary.Model
{
    public class UserSearchModel : BaseSearchModel
    {
        public string UserCode { get; set; }
        public string WxOpenId { get; set; }

    }
}
