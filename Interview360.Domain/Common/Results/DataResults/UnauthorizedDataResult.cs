using System.Net;
using Interview360.Domain.Common.Results.Base;
    
namespace Interview360.Domain.Common.Results.DataResults
{
    public class UnauthorizedDataResult<T> : DataResult<T>
    {
        public UnauthorizedDataResult(T data, string message) : base(data, StatusTypeEnum.Unauthorized,
            (int)HttpStatusCode.Unauthorized, message)
        {
        }

        public UnauthorizedDataResult(T data) : base(data, StatusTypeEnum.Unauthorized,
            (int)HttpStatusCode.Unauthorized)
        {
        }

        public UnauthorizedDataResult(string message) : base(default, StatusTypeEnum.Unauthorized,
            (int)HttpStatusCode.Unauthorized, message)
        {
        }

        public UnauthorizedDataResult() : base(default, StatusTypeEnum.Unauthorized, (int)HttpStatusCode.Unauthorized)
        {
        }
    }
}