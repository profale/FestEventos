using FestEventosDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FestEventosDomain.Contracts.IServices
{
    public interface ILocalService
    {
        void AdicionarLocal(Local local);
        Task<Local> ObterLocal(Guid id);
        void AtualizarLocal(Local local);
        IEnumerable<Local> ListarLocais();
    }
}
