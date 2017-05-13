using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGMI.Models
{
    public class MembrosModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        [StringLength(100,
                      ErrorMessage = "O campo {0} tem no máximo {1} e no mínimo {2} caracteres",
                      MinimumLength = 10
            )]
        [Display(Name = "Nome do Membro")]
        public string Nome { get; set; }


        [StringLength(15,
                      ErrorMessage = "O campo {0} tem no máximo {1}"
            )]
        public string Telefone { get; set; }

        
        [StringLength(100,
                      ErrorMessage = "O campo {0} tem no máximo {1} e no mínimo {2} caracteres",
                      MinimumLength = 4
            )]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        [StringLength(14,
                      ErrorMessage = "O campo {0} tem no máximo {1}")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        [StringLength(200,
                      ErrorMessage = "O campo {0} tem no máximo {1} e no mínimo {2} caracteres",
                      MinimumLength = 10
            )]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }

        public virtual CidadeModels Cidade { get; set; }

    }
}