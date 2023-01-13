using Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Api.Service.Stock.Models
{
    public partial class Produto : BaseData, IProduto 
    {
        public Produto()
        {
            DbItensCompraModel = new List<ItensCompra>();
            DbItensVendasModel = new List<ItensVenda>();
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorVenda { get; set; }
        public int Estoque { get; set; }
        public EStatus Status { get; set; }

        public List<IItensCompra> ItensCompras => new List<IItensCompra>(DbItensCompraModel);

        public List<ItensCompra> DbItensCompraModel { get; set; }

        public List<ItensVenda> DbItensVendasModel { get; set; }

        public List<IItensVenda> ItensVendas => new List<IItensVenda>(DbItensVendasModel);

    }
}
