using System;

namespace GrowthDiary.Model
{
    /// <summary>
    /// 记录类型定义
    /// </summary>
    public class RecordTypeDefinition:BaseModel
    {
        /// <summary>
        /// 记录类型
        /// </summary>
        public RecordType RecordType { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public float MaxValue{ get; set; }
        /// <summary>
        /// 最小值
        /// </summary>
        public float MinValue { get; set; }
    }
}
