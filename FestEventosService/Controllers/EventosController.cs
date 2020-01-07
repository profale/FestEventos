using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FestEventosDomain.Entities;
using FestEventosInfra.DataContext;
using FestEventosDomain.Contracts.IServices;
using FestEventosService.ViewModel;

namespace FestEventosService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly FestEventoContext _context;
        private readonly IEventoService _eventoService;
        
        public EventosController(FestEventoContext context, IEventoService eventoService)
        {
            _context = context;
            _eventoService = eventoService;
        }

        // GET: api/Eventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
            return await _context.Eventos.ToListAsync();
        }

        // GET: api/Eventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(Guid id)
        {
            var evento = await _context.Eventos.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        // PUT: api/Eventos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(Guid id, Evento evento)
        {
            if (id != evento.Id)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Eventos
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(EventoViewModel eventoViewModel)
        {
            var evento = new Evento
            {
                Id = eventoViewModel.Id,
                Nome = eventoViewModel.Nome,
                EventoLocais = eventoViewModel.Locais.Select(id => new EventoLocal { LocalId = id }).ToList()
            };

            _eventoService.AdicionarEvento(evento);
            //_context.Eventos.Add(evento);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = evento.Id }, evento);
        }

        // DELETE: api/Eventos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Evento>> DeleteEvento(Guid id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return evento;
        }

        private bool EventoExists(Guid id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
