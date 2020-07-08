using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class ConsultaSegurado
    {
        public ConsultaSegurado()
        {

        }

        public async Task<Segurado> GetSegurado(string cpf)
        {
            string url = $"http://my-json-server.typicode.com/sloss-k2/json-server-db/segurados/?cpf={cpf}";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            Segurado segurado = JsonConvert.DeserializeObject<List<Segurado>>(responseBody).FirstOrDefault();
            return segurado;
        }

    }
}