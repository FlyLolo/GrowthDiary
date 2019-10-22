using System;
using System.Collections.Generic;

namespace GrowthDiary.Model
{
    public class PagesModel<T>
    {
        public PageSeting PageSeting { get; set; }
        public List<T> Items { get; set; }
    }
}
