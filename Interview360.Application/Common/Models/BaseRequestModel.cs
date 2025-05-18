using Interview360.Domain.Common.Results.Base;
using MediatR;

namespace Interview360.Application.Common.Models;

public abstract record BaseRequestModel<TResponse> : IRequest<IDataResult<TResponse>>
{
}