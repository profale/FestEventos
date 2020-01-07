using System;
using System.Collections.Generic;
using System.Text;

namespace FestEventosDomain.Entities
{
    public class EventoLocal
    {
        public DateTime DataEvento { get; set; }
        public Guid EventoId { get; set; }
        public Evento Evento { get; set; }
        public Guid LocalId { get; set; }
        public Local Local { get; set; }
    }
}
