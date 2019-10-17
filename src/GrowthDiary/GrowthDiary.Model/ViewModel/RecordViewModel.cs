using System;

namespace GrowthDiary.Model
{
    public class RecordViewModel : BaseViewModel
    {
        public string UserCode { get; set; }
        public string UserName { get; set; }

        public RecordType RecordType { get; set; }
        public float Value { get; set; }
    }
}
