using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Safirex.Models
{
    public class TipoSetor
    {
        public int TipoSetorId { get; set; }

        [Required]
        [Display(Name = "Tipo de Setor")]
        public string Descricao { get; set; }

    }
}