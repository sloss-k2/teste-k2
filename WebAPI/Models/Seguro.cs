using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Seguro
    {
        public long Id { get; set; }

        public long IdSegurado { get; set; }

        public string MarcaModelo { get; set; }

        public double ValorVeiculo { get; set; }

        public double ValorSeguro { get; set; }
    }
}