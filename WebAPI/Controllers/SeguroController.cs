using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.Models;
using WebAPI.Properties;
using WebAPI.Services;
using Oracle.ManagedDataAccess.Client;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class SeguroController : Controller
    {
        //[HttpPost]
        public ActionResult Index()
        {
            ViewBag.Title = "Seguro";

            string cpf = Request.Form["cpf"];
            string marcaModelo = Request.Form["marcaModelo"];
            double valorVeiculo = Convert.ToDouble(Request.Form["valor"]);

            Segurado segurado = GetSegurado(cpf);

            double valorSeguro = CalculaSeguro(valorVeiculo);

            Seguro seguro = new Seguro() { 
                IdSegurado = segurado.Id,
                MarcaModelo = marcaModelo,
                ValorVeiculo = valorVeiculo,
                ValorSeguro = Math.Round(valorSeguro, 2)
            };

            GravaSeguro(seguro);

            ViewBag.Segurado = segurado;
            ViewBag.Seguro = seguro;
            return View();
        }

        private void GravaSeguro(Seguro seguro)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string cmdText = $"INSERT INTO TESTEK2.SEGURO (ID, SEGURADOID, MARCAMODELO, VALORVEICULO, VALORSEGURO) VALUES ('{Guid.NewGuid()}', {seguro.IdSegurado}, '{seguro.MarcaModelo}', {seguro.ValorVeiculo}, {seguro.ValorSeguro})";
                using (OracleCommand cmd = new OracleCommand(cmdText, conn))
                {
                    int insert = cmd.ExecuteNonQuery();
                }

                conn.Close();
            }

        }

        private Segurado GetSegurado(string cpf)
        {            
            ConsultaSegurado cs = new ConsultaSegurado();
            Segurado segurado = Task.Run(() => cs.GetSegurado(cpf)).Result;
            return segurado;
        }

        private double CalculaSeguro(double valorVeiculo)
        {
            double margemSegurancaPercent = ((double)Settings.Default.MARGEM_SEGURANCA / 100);
            double lucroPercent = ((double)Settings.Default.LUCRO / 100);
            double taxaDeRisco = ((valorVeiculo * 5) / (2 * valorVeiculo)) / 100;
            double premioDeRisco = taxaDeRisco * valorVeiculo;
            double premioPuro = premioDeRisco * (1 + margemSegurancaPercent);
            double premioComercial = premioPuro + (lucroPercent * premioPuro);

            return premioComercial;
        }
    }
}

