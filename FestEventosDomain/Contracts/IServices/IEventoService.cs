using FestEventosDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FestEventosDomain.Contracts.IServices
{
    public interface IEventoService
    {
        void AdicionarEvento(Evento evento);
        Task<Evento> ObterEvento(Guid id);
        void AtualizarEvento(Evento evento);
        IEnumerable<Evento> ListarEventos();
    }
}
