using Lingo.Models;

namespace Lingo.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LingoContext _db;

        public UnitOfWork(LingoContext db)
        {
            _db = db;
        }
        
        public Task SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}