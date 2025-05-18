namespace Interview360.Application.Common.Dtos;

public interface IDto
{
}

public interface IDto<TKey> : IDto
{
    TKey Id { get; }
}