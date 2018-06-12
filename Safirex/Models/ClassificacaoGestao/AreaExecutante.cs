using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Safirex.Models.ClassificacaoGestao
{
    public class AreaExecutante
    {
        public int AreaExecutanteId { get; set; }
        [Required] [Display(Name = "Nome da Area")]
        public string Descricao { get; set; }
    }
}