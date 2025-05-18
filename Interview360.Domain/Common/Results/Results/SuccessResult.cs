using Interview360.Domain.Common.Results.Base;
using System.Net;

namespace Interview360.Domain.Common.Results.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(StatusTypeEnum.Success, (int)HttpStatusCode.OK, message)
        {
        }

        public SuccessResult() : base(StatusTypeEnum.Success, (int)HttpStatusCode.OK)
        {
        }
    }
}