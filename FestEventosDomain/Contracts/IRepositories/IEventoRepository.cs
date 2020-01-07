using FestEventosDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FestEventosDomain.Contracts.IRepositories
{
    public interface IEventoRepository
    {
        void Create(Evento evento);
        void Update(Evento evento);
        Evento Obter(Guid id);
        void Remove(Guid id);
        IEnumerable<Evento> Listar();
    }
}
