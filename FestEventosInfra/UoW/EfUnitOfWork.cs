using FestEventosDomain.Contracts.UoW;
using FestEventosInfra.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FestEventosInfra.UoW
{
    public class EfUnitOfWork : IUnnitOfWork
    {
        private FestEventoContext _context;
        private bool _dispose;

        public EfUnitOfWork(FestEventoContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();   
        }

        public int Commit()
        {
            var result = _context.SaveChanges();
            _context.Database.CommitTransaction();
            return result;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
