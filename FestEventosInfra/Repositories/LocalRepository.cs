using FestEventosDomain.Contracts.IRepositories;
using FestEventosDomain.Entities;
using FestEventosInfra.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FestEventosInfra.Repositories
{
    public class LocalRepository : ILocalRepository
    {
        private readonly FestEventoContext _context;

        public LocalRepository(FestEventoContext context)
        {
            _context = context;
        }
        public void Create(Local local)
        {
            _context.Add(local);
            _context.SaveChanges();
        }

        public IEnumerable<Local> Listar()
        {
            return _context.Locais;
        }

        public Local Obter(Guid id)
        {
            //var xxx = _context.Locais.ToList();
            return _context.Locais.Find(id);
        }

        public void Remove(Guid id)
        {
            _context.Remove(id);
        }

        public void Update(Local local)
        {
            _context.Update<Local>(local);
        }
    }
}
