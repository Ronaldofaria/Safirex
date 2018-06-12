using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Safirex.Models.ClassificacaoEstrutura
{
    public class Secretaria
    {
        public int GovernoId { get; set; }
        public virtual Governo Governo { get; set; }
        public int SecretariaId { get; set; }
        [Display(Name = "Sigla Secretaria")]
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }

    }
}