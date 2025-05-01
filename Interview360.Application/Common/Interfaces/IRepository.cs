using Interview360.Domain.Abstraction;
using System.Linq.Expressions;

namespace Interview360.Application.Common.Interfaces;

public interface IRepository<T> where T : Entity<Guid>
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    Task<int> SaveChangesAsync();
    IQueryable<T> Query();
} 