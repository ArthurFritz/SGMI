using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGMI.Models
{
    public class CidadeModels
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        [StringLength(150,
                      ErrorMessage = "O campo {0} tem no máximo {1} e no mínimo {2} caracteres",
                      MinimumLength = 5
            )]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }

        public virtual EstadoModels Estado { get; set; }
        public IEnumerable<MembrosModel> Membros { get; set; }
    }
}