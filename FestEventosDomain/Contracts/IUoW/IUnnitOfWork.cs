using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FestEventosDomain.Contracts.UoW
{
    public interface IUnnitOfWork
    {
        void BeginTransaction();
        int Commit();
        Task<int> CommitAsync();
        void Rollback();
    }
}
