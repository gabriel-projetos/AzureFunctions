using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface ICliente : IBaseModel
    {
        string Nome { get; set; }
        string Rg { get; set; }
        string Cep { get; set; }
        string Endereco { get; set; }
        string Fone { get; set; }
        string Cel { get; set; }
        string EnderecoNumero { get; set; }
        string Cidade { get; set; }
        string Uf { get; set; }
        List<IVenda> Vendas { get; }
    }
}
