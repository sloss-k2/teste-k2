using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Veiculo
    {

        public long Id { get; set; }

        public string MarcaModelo { get; set; }

        public double Valor { get; set; }
    }
}