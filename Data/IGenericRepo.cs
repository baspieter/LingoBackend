using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lingo.Data
{
    public interface IGenericRepo<T> where T: class, new()
    {
        // Task<T> GetByIdAsync(int id);
        // Task<IEnumerable<T>> GetAllAsync();
        // Task DeleteAsync(int id);
        Task AddAsync(T t);
        // Task UpdateAsync(T t);
    }
}