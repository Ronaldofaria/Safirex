using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Safirex.Models.ClassificacaoOrigem
{
    public class NivelGerencial
    {
        public int NivelGerencialId { get; set; }
        [Required] [Display(Name = "Nome do Nivel Gerencial")]
        public string Descricao { get; set; }
    }
}