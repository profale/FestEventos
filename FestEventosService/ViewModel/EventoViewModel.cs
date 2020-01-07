using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FestEventosService.ViewModel
{
    public class EventoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<Guid> Locais { get; set; }
    }
}
