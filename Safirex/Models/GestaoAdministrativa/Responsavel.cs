using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Safirex.Models.GestaoAdministrativa
{
    public class Responsavel
    {
        public int ResponsavelId { get; set; }
        public string Nome { get; set; }
        public string IdFuncional { get; set; }
        public string Matricula { get; set; }
    }
}