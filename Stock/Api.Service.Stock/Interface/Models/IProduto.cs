using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IProduto : IBaseModel
    {
        string Nome { get; set; }
        string Descricao { get; set; }
        byte[] Imagem { get; set; }
        decimal ValorPago { get; set; }
        decimal ValorVenda { get; set; }
        int Estoque { get; set; }
        EStatus Status { get; set; }
        List<IItensCompra> ItensCompras { get; }
        List<IItensVenda> ItensVendas { get; }
    }

    public enum EStatus
    {
        Ativo = 1,
        Inativo = 0
    }
}
