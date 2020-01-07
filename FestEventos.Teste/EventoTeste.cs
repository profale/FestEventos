using FestEventosDomain.Contracts.IRepositories;
using FestEventosDomain.Contracts.IServices;
using FestEventosDomain.Contracts.UoW;
using FestEventosDomain.Entities;
using FestEventosDomain.Services;
using FestEventosInfra.DataContext;
using FestEventosInfra.Repositories;
using FestEventosInfra.UoW;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FestEventos.Teste
{
    [TestClass]
    public class EventoTeste
    {
        private readonly IEventoService _eventoService;
        private static FestEventoContext context = new FestEventoContext();
        private static EventoRepository _eventoRepository = new EventoRepository(context);
        private static LocalRepository _localRepository = new LocalRepository(context);
        private ILocalService _localService;
        private static EventoLocalRepository _eventoLocalRepository = new EventoLocalRepository(context);

        public EventoTeste()
        {
            _eventoService = new EventoService(new EfUnitOfWork(context),_eventoRepository);
            _localService = new LocalService(new EfUnitOfWork(context), _localRepository);
        }

        [TestMethod]
        public void IncluirEvento()
        {
            IList<EventoLocal> locaisList = new List<EventoLocal>();

            var evento = new Evento
            {
                Id = Guid.NewGuid(),
                Nome = "Palestra Adolescentes na Tecnologia",
            };

            //var local = _localService.ObterLocal(Guid.Parse("0BE4BEFC-4187-40BD-9582-07C91112C6B0")).Result;
            var locais = _localService.ListarLocais();
            

            foreach (Local item in locais)
            {
                EventoLocal eventoLocal = new EventoLocal();
                eventoLocal.EventoId = evento.Id;
                eventoLocal.LocalId = item.Id;
                eventoLocal.DataEvento = DateTime.Now;
                locaisList.Add(eventoLocal);
            }
            
            //var eventoLocal = new EventoLocal
            //{
            //    EventoId = evento.Id,
            //    LocalId = local.Id,
            //    DataEvento = DateTime.Now

            //};


            //locaisList.Add(eventoLocal);

            evento.EventoLocais = locaisList;

            _eventoService.AdicionarEvento(evento);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ListarEvento()
        {
            var eventos = _eventoService.ListarEventos();
            Assert.IsTrue(eventos.ToList().Count > 0);
        }

        [TestMethod]
        public void ObterEventos()
        {
            var evento = _eventoService.ObterEvento(Guid.Parse("5AB392C4-06C7-45AF-BD01-113A1E9601E3")).Result;
            Assert.IsTrue(evento != null);
        }

        [TestMethod]
        public void AtualizarEvento()
        {
            
            var evento = _eventoService.ObterEvento(Guid.Parse("06969DB4-6089-4346-A76C-C7AE2D48EC54")).Result;
            //Atualizar
            evento.Data = DateTime.Now;
            evento.Quantidade = 50;

            _eventoService.AtualizarEvento(evento);
            var evento2 = _eventoService.ObterEvento(Guid.Parse("06969DB4-6089-4346-A76C-C7AE2D48EC54")).Result;

            Assert.AreEqual(evento, evento2);
        }

        //[TestMethod]
        //public void InserirEventoLocal()
        //{
        //    var evento = _eventoRepository.Obter(Guid.Parse("E68DFA31-03E1-499E-92A2-61647218E8AD"));
        //    var local = _localRepository.Obter(Guid.Parse("0BE4BEFC-4187-40BD-9582-07C91112C6B0"));

        //    var eventoLocal = new EventoLocal
        //    {
        //        EventoId = evento.Id,
        //        //Evento = new Evento
        //        //{
        //        //    Id = Guid.NewGuid(),
        //        //    Nome = "Show da Anita"
        //        //},
        //        LocalId = local.Id,
        //        //Local = new Local
        //        //{
        //        //    Id = Guid.NewGuid(),
        //        //    Nome = "Casa da mae Joana"

        //        //},
        //        DataEvento = DateTime.Now
        //    };

        //    _eventoLocalRepository.Create(eventoLocal);

        //    var evento2 = _eventoLocalRepository.Obter(eventoLocal.EventoId, eventoLocal.LocalId);

        //    Assert.AreEqual(evento2, eventoLocal);
        //}
    }
}
