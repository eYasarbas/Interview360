using Interview360.Domain.Common.Results.Base;
using System.Net;

namespace Interview360.Domain.Common.Results.Results
{
    public class UnauthorizedResult : Result
    {
        public UnauthorizedResult(string message) : base(StatusTypeEnum.Unauthorized, (int)HttpStatusCode.Unauthorized,
            message)
        {
        }

        public UnauthorizedResult() : base(StatusTypeEnum.Unauthorized, (int)HttpStatusCode.Unauthorized)
        {
        }
    }
}