using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Safirex.Models.ClassificacaoEstrutura
{
    public class Subsecretaria
    {
        public int SubsecretariaId { get; set; }

        public virtual Secretaria Secretaria { get; set; }
        public int SecretariaId { get; set; }
        [Display(Name = "Sigla Subsecretaria")]
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public string Andar { get; set; }
        public string Sala { get; set; }
    }
}