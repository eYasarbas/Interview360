using System.Net;
using Interview360.Domain.Common.Results.Base;

namespace Interview360.Domain.Common.Results.Results
{
    public class WarningResult : Result
    {
        public WarningResult(string message) : base(StatusTypeEnum.Warning, (int)HttpStatusCode.BadRequest, message)
        {
        }

        public WarningResult() : base(StatusTypeEnum.Warning, (int)HttpStatusCode.BadRequest)
        {
        }
    }
}
