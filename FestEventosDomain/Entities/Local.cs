using System;
using System.Collections.Generic;
using System.Text;

namespace FestEventosDomain.Entities
{
    public class Local
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public IList<EventoLocal> EventoLocais { get; set; } = new List<EventoLocal>();
    }
}
