
   
using System.Threading.Tasks;

namespace Lingo.Data
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync();
    }
}