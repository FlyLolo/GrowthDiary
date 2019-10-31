using System;

namespace GrowthDiary.ViewModel
{
    public class RecordViewModel : BaseViewModel
    {
        public string UserCode { get; set; }
        public string UserName { get; set; }

        public int ValueType { get; set; }
        public float Value { get; set; }
    }

    public class RecordSearchViewModel : BaseSearchViewModel
    {

    }
}
