using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGMI.Models
{
    public class EstadoModels
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        [StringLength(150,
                      ErrorMessage = "O campo {0} tem no máximo {1} e no mínimo {2} caracteres",
                      MinimumLength = 5
            )]
        [Display(Name = "Estado")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        [StringLength(2,
                      ErrorMessage = "O campo {0} tem no máximo {1}"
            )]
        [Display(Name = "Sigla")]
        public string Sigla { get; set; }

        public IEnumerable<CidadeModels> Cidades { get; set; }
    }
}