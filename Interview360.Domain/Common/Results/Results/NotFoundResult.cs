using Interview360.Domain.Common.Results.Base;
using System.Net;

namespace Interview360.Domain.Common.Results.Results
{
    public class NotFoundResult : Result
    {
        public NotFoundResult(string message) : base(StatusTypeEnum.NotFound, (int)HttpStatusCode.NotFound, message)
        {
        }

        public NotFoundResult() : base(StatusTypeEnum.NotFound, (int)HttpStatusCode.OK)
        {
        }
    }
}