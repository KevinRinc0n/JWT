using System.Linq.Expressions;
using Dominio.Entities;

namespace Dominio.Interfaces;

   public interface IGenericRepositor<T> where T : BaseEntity
   {
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
   }
