using GrowthDiary.Model.Base;
using System;
using System.Collections.Generic;

namespace GrowthDiary.Model
{
    public class PagesModel<T>
    {
        public PagesModel(List<T> items,BaseSearchModel searchModel) 
        {
            IsPagination = searchModel.IsPagination;
            PageIndex = searchModel.PageIndex;
            PageSize = searchModel.PageSize;
            RecordCount = searchModel.RecordCount;
            Items = items;
        }

        public bool IsPagination { get; set; } = true;  //是否分页
        public int PageIndex { get; set; } = 1;         //页码
        public int PageSize { get; set; } = 10;         //每页10行
        public int RecordCount { get; set; } = 0;       //总行数

        public List<T> Items { get; set; }
    }
}
