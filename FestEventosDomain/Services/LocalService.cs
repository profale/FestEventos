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
    public class LocalService : ILocalService
    {
        private readonly IUnnitOfWork _unnitOfWork;
        private readonly ILocalRepository _localRepository;

        public LocalService(IUnnitOfWork unnitOfWork, ILocalRepository localRepository)
        {
            _unnitOfWork = unnitOfWork;
            _localRepository = localRepository;
        }

        public void AdicionarLocal(Local local)
        {
            _unnitOfWork.BeginTransaction();
            _localRepository.Create(local);
            _unnitOfWork.Commit();
        }

        public void AtualizarLocal(Local local)
        {
            _unnitOfWork.BeginTransaction();
            _localRepository.Update(local);
            _unnitOfWork.Commit();
        }

        public IEnumerable<Local> ListarLocais()
        {
            return _localRepository.Listar();
        }

        public async Task<Local> ObterLocal(Guid id)
        {
            return _localRepository.Obter(id);
        }
    }
}
