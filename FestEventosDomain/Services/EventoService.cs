using FestEventosDomain.Contracts.IRepositories;
using FestEventosDomain.Contracts.IServices;
using FestEventosDomain.Contracts.UoW;
using FestEventosDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FestEventosDomain.Services
{
    public class EventoService : IEventoService
    {
        private readonly IUnnitOfWork _unnitOfWork;
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IUnnitOfWork unnitOfWork, IEventoRepository eventoRepository)
        {
            _unnitOfWork = unnitOfWork;
            _eventoRepository = eventoRepository;
        }

        public void AdicionarEvento(Evento evento)
        {
            _unnitOfWork.BeginTransaction();
            _eventoRepository.Create(evento);
            _unnitOfWork.Commit();
        }

        public void AtualizarEvento(Evento evento)
        {
            _unnitOfWork.BeginTransaction();
            _eventoRepository.Update(evento);
            _unnitOfWork.Commit();
        }

        public IEnumerable<Evento> ListarEventos()
        {
            return _eventoRepository.Listar();
        }

        public async Task<Evento> ObterEvento(Guid id)
        {
            return _eventoRepository.Obter(id);
        }

    }
}
