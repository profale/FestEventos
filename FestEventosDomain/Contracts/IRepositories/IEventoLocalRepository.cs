using FestEventosDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FestEventosDomain.Contracts.IRepositories
{
    public interface IEventoLocalRepository
    {
        void Create(EventoLocal eventoLocal);
        void Update(EventoLocal eventoLocal);
        EventoLocal Obter(Guid eventoId, Guid localId);
        void Remove(Guid id);
        IEnumerable<EventoLocal> Listar();
    }
}
