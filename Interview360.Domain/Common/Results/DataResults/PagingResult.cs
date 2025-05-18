using Interview360.Domain.Common.Results.Base;
using System.Net;

namespace Interview360.Domain.Common.Results.DataResults
{
    public class PagingResult<T> : Result, IPagingResult<T>
    {
        public PagingResult(
            List<T> data, int recordsTotal, int recordsFiltered, int? draw, string message
        ) : base(StatusTypeEnum.Success, (int)HttpStatusCode.OK, message)
        {
            Data = data;
            RecordsTotal = recordsTotal;
            RecordsFiltered = recordsFiltered;
            Draw = draw;
        }

        public List<T> Data { get; }
        public int RecordsTotal { get; }
        public int RecordsFiltered { get; }
        public int? Draw { get; }
    }
}