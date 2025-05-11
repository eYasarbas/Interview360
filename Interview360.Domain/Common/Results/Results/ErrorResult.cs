using System.Net;
using Interview360.Domain.Common.Results.Base;

namespace Interview360.Domain.Common.Results.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(StatusTypeEnum.Failed, (int)HttpStatusCode.BadRequest, message)
        {
        }

        public ErrorResult() : base(StatusTypeEnum.Failed, (int)HttpStatusCode.BadRequest)
        {
        }
    }
}