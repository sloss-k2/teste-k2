using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Segurado
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public int Idade { get; set; }

    }
}