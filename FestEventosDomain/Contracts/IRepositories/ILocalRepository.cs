using FestEventosDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FestEventosDomain.Contracts.IRepositories
{
    public interface ILocalRepository
    {
        void Create(Local local);
        void Update(Local local);
        Local Obter(Guid id);
        void Remove(Guid id);
        IEnumerable<Local> Listar();
    }
}
