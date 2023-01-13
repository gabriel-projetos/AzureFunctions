using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IFornecedor : IBaseModel
    {
        string Nome { get; set; }
        string Cnpj { get; set; }
        string Cep { get; set; }
        string Endereco { get; set; }
        string Bairro { get; set; }
        string Fone { get; set; }
        string Cel { get; set; }
        string Email { get; set; }
        string EnderecoNumero { get; set; }
        string Cidade { get; set; }
        string Estado { get; set; }
        List<ICompra> Compras { get; }
    }
}
