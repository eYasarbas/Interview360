using AutoMapper;
using Interview360.Application.Common.Models;
using Interview360.Domain.Common.Results.Base;
using MediatR;

namespace Interview360.Application.Common.Handlers;

public abstract class BaseRequestHandler<TRequest, TResponse>
    : IRequestHandler<TRequest, IDataResult<TResponse>>
    where TRequest : BaseRequestModel<TResponse>
{
    protected readonly IMapper _mapper;

    protected BaseRequestHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public abstract Task<IDataResult<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
}