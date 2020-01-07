using FestEventosDomain.Contracts.IRepositories;
using FestEventosDomain.Entities;
using FestEventosInfra.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FestEventosInfra.Repositories
{
    public class EventoLocalRepository : IEventoLocalRepository
    {
        private readonly FestEventoContext _context;

        public EventoLocalRepository(FestEventoContext context)
        {
            _context = context;
        }

        public void Create(EventoLocal eventoLocal)
        {
            _context.Add(eventoLocal);
        }

        public IEnumerable<EventoLocal> Listar()
        {
            return _context.EventosLocais;
        }

        public EventoLocal Obter(Guid eventoId, Guid localId)
        {
            return _context.EventosLocais.FirstOrDefault(e => e.EventoId == eventoId && e.LocalId == localId);
        }

        public void Remove(Guid id)
        {
            _context.Remove(id);
        }

        public void Update(EventoLocal eventoLocal)
        {
            _context.Update<EventoLocal>(eventoLocal);
        }
    }
}
