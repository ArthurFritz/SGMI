using System.Collections.Generic;

namespace SGMI.Models
{
    public class EstadoModels
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public IEnumerable<CidadeModels> Cidades { get; set; }
    }
}