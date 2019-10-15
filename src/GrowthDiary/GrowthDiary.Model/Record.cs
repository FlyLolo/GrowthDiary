using System;

namespace GrowthDiary.Model
{
    public class Record : BaseModel
    {
        public string UserCode { get; set; }
        public string UserName { get; set; }

        public int ValueType { get; set; }
        public float Value { get; set; }
        public int State { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
