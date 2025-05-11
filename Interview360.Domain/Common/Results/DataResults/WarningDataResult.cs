using System.Net;
using Interview360.Domain.Common.Results.Base;

namespace Interview360.Domain.Common.Results.DataResults
{
    public class WarningDataResult<T> : DataResult<T>
    {
        public WarningDataResult(T data, string message) : base(data, StatusTypeEnum.Warning, (int)HttpStatusCode.OK,
            message)
        {
        }

        public WarningDataResult(T data) : base(data, StatusTypeEnum.Warning, (int)HttpStatusCode.OK)
        {
        }

        public WarningDataResult(string message) : base(default, StatusTypeEnum.Warning, (int)HttpStatusCode.OK,
            message)
        {
        }

        public WarningDataResult() : base(default, StatusTypeEnum.Warning, (int)HttpStatusCode.OK)
        {
        }
    }
}