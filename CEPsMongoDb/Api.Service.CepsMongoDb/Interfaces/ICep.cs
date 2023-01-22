using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.CepsMongoDb.Interfaces
{
    public interface ICep
    {
        string Id { get; set; }
        string Cep { get; set; }
        string Logradouro { get; set; }
        string Complemento { get; set; }
        string Bairro { get; set; }
        string Localidade { get; set; }
        string Uf { get; set; }
        string Ibge { get; set; }
        string Gia { get; set; }
        string Ddd { get; set; }
        string Siafi { get; set; }
    }
}
