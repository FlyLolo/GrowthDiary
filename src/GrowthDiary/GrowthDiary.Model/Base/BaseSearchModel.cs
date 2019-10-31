using System;
namespace GrowthDiary.Model.Base
{
    public class BaseSearchModel
    {
        public bool IsPagination { get; set; } = true;  //是否分页
        public int PageIndex { get; set; } = 1;         //页码
        public int PageSize { get; set; } = 10;         //每页10行
        public int RecordCount { get; set; } = 0;       //总行数
    }
}
