using System;

namespace GrowthDiary.Model
{
    /// <summary>
    /// 记录
    /// </summary>
    public class RecordViewModel : BaseViewModel
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
        public int State { get; set; } = 1;
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

    }
}
