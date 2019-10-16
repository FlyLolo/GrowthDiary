using System;

namespace GrowthDiary.Model
{
    /// <summary>
    /// 记录类型枚举
    /// </summary>
    public enum RecordType
    {
        Height = 1,  //身高
        Weight = 2   //体重
    }

    /// <summary>
    /// 记录类型定义
    /// </summary>
    public class RecordTypeDefinition
    {
        /// <summary>
        /// 记录类型
        /// </summary>
        public RecordType RecordType { get; set; }
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


    /// <summary>
    /// 记录
    /// </summary>
    public class Record : BaseModel
    {
        /// <summary>
        /// 操作用户Code
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 操作用户Name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 记录类型
        /// </summary>
        public int RecordType { get; set; }
        /// <summary>
        /// 记录值
        /// </summary>
        public float Value { get; set; }
        /// <summary>
        /// 记录状态 默认为1 正常 2 逻辑删除
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }

    public class RecordSearchModel : BaseSearchModel
    {
        public int State { get; set; }

    }
}
