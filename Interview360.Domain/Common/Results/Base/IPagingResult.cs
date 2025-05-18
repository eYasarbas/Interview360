namespace Interview360.Domain.Common.Results.Base
{
    public interface IPagingResult<T> : IResult
    {
        /// <summary>
        /// data list
        /// </summary>
        List<T> Data { get; }

        /// <summary>
        /// Total records, before filtering
        /// </summary>
        int RecordsTotal { get; }

        /// <summary>
        /// Total records, after filtering
        /// </summary>
        int RecordsFiltered { get; }

        /// <summary>
        /// strongly recommended for security reasons
        /// </summary>
        int? Draw { get; }
    }
}