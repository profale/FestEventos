using FestEventosDomain.Contracts.IServices;
using FestEventosDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FestEventosWebApp.Controllers
{
    public class EventosController : ApiController
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpPost]
        public HttpResponseMessage Post(Evento evento)
        {
            _eventoService.AdicionarEvento(evento);
            return Request.CreateResponse(HttpStatusCode.OK, evento);
        }
    }
}
