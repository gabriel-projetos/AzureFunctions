using Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Api.Service.Stock.Models
{
    public partial class ItensCompra : BaseData, IItensCompra
    {
        public double? Quantidade { get; set; }
        public decimal? Valor { get; set; }
        
        public Guid CompraUid { get; set; }
        public Compra DbCompra { get; set; }
        public Guid ProdutoUid { get; set; }
        public Produto DbProduto { get; set; }
    }
}
