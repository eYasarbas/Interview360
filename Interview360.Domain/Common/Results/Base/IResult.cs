namespace Interview360.Domain.Common.Results.Base
{
    public interface IResult
    {
        StatusTypeEnum Status { get; }
        string Message { get; }
        int StatusCode { get; }
    }
}