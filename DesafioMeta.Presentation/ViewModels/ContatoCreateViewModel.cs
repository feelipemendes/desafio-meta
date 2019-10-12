using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMeta.Presentation.ViewModels
{
    public class ContatoCreateViewModel
    {
        [Required(ErrorMessage = "{0} é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} deve ser um canal válido.")]
        public string Canal { get; set; }

        [Required(ErrorMessage = "{0} deve ser um valor válido.")]
        public string Valor { get; set; }
        
        public string Obs { get; set; }
    }
}
