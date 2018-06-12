using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Safirex.Models.GestaoAdministrativa;

namespace Safirex.Models.ClassificacaoEstrutura
{
    public class Setor
    {
        public int SetorId { get; set; }

        public virtual Secretaria Secretaria { get; set; }
        public int SecretariaId { get; set; }

        public virtual Subsecretaria Subsecretaria { get; set; }
        public int SubsecretariaId { get; set; }

        public virtual TipoSetor TipoSetor { get; set; }
        public int TipoSetorId { get; set; }

        [Display(Name = "Setor")]
        public string Nome { get; set; }
        [Display(Name = "Sigla Setor")]
        public string Sigla { get; set; }
        public string Andar { get; set; }
        public string Sala { get; set; }

        public virtual Responsavel Responsavel { get; set; }
        public int ResponsavelId { get; set; }
    }
}