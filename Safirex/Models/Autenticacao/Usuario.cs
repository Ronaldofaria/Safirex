﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Safirex.Models.Domain
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NomeCompleto { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}