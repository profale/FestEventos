using FestEventosDomain.Contracts.IRepositories;
using FestEventosDomain.Contracts.IServices;
using FestEventosDomain.Entities;
using FestEventosDomain.Services;
using FestEventosInfra.DataContext;
using FestEventosInfra.Repositories;
using FestEventosInfra.UoW;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FestEventos.Teste
{
    [TestClass]
    public class LocalTeste
    {
        private static FestEventoContext context = new FestEventoContext();
        private readonly ILocalService _localService;
        private readonly LocalRepository localRepository = new LocalRepository(context);

        public LocalTeste()
        {
            _localService = new LocalService(new EfUnitOfWork(context), localRepository);
        }

        [TestMethod]
        public void AdicionarLocal()
        {
            var local = new Local
            {
                Id = Guid.NewGuid(),
                Nome = "PR"
            };

            _localService.AdicionarLocal(local);

            Assert.IsTrue(true);

        }

        [TestMethod]
        public void AtualizarLocal()
        {
            var local = _localService.ObterLocal(Guid.Parse("0BE4BEFC-4187-40BD-9582-07C91112C6B0")).Result;
            local.Nome = "Barra Music";

            _localService.AtualizarLocal(local);
            var localAlterado = _localService.ObterLocal(Guid.Parse("0BE4BEFC-4187-40BD-9582-07C91112C6B0")).Result;

            Assert.AreEqual(local, localAlterado);
        }

        [TestMethod]
        public void ObterLocal()
        {
            var local = _localService.ObterLocal(Guid.Parse("0BE4BEFC-4187-40BD-9582-07C91112C6B0")).Result;
            Assert.IsTrue(local != null);
        }

        [TestMethod]
        public void Listar()
        {
            var locais = _localService.ListarLocais();
            Assert.IsTrue(locais.ToList().Count > 0);
        }
    }
}
