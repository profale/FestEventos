using FestEventosDomain.Contracts.IRepositories;
using FestEventosDomain.Contracts.UoW;
using FestEventosDomain.Entities;
using FestEventosInfra.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FestEventosInfra.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly FestEventoContext _context;

        public EventoRepository(FestEventoContext context)
        {
            _context = context;
        }

        public void Create(Evento evento)
        {
           _context.Add(evento);
        }

        public IEnumerable<Evento> Listar()
        {
            return _context.Eventos;
        }

        public Evento Obter(Guid id)
        {
            return _context.Eventos.Find(id);
        }

        public void Remove(Guid id)
        {
            _context.Remove(id);
        }

        public void Update(Evento evento)
        {
            _context.Update<Evento>(evento);
        }


    }
}
