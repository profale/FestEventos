using System;
using System.Collections.Generic;
using System.Text;

namespace FestEventosDomain.Entities
{
    public class Evento
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }

        public IList<EventoLocal> EventoLocais { get; set; } = new List<EventoLocal>();
    }
}
