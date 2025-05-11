namespace Interview360.Domain.Common.Results.Base
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}