using Safirex.Models.ClassificacaoOrigem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Safirex.Models.ClassificacaoEstrutura
{
    public class Governo
    {
        public int EsferaId { get; set; }
        public virtual Esfera Esfera { get; set; }
        public int GovernoId { get; set; }
        public string Nome { get; set; }
    }
}