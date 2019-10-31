using System.Collections.Generic;

namespace GrowthDiary.Common
{
    public enum ReturnCode
    {
        ArgsError = -1001,
        LoginError = -1002,
        GeneralError = -1003,
        Success = 0,
    }


    public class ApiResult
    {
        private static readonly Dictionary<ReturnCode, string> codeMessageDict = new Dictionary<ReturnCode, string>() { { ReturnCode.Success, "操作成功。" }, { ReturnCode.ArgsError, "参数错误。" }, { ReturnCode.GeneralError, "操作错误。" }, { ReturnCode.LoginError, "用户名或密码错误。" } };

        public ApiResult(ReturnCode returnCode = ReturnCode.Success, string msg = null)
        {
            Code = returnCode;
            Message = msg ?? (codeMessageDict[returnCode] ?? "未知错误。");
        }

        public ReturnCode Code { get; set; }
        public string Message { get; set; }
    }

    public class ApiResult<T> : ApiResult
    {
        public ApiResult(T data, ReturnCode returnCode = ReturnCode.Success, string msg = null) : base(returnCode, msg)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
