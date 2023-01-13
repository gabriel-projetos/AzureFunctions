using Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Api.Service.Stock.Models
{
    public partial class ItensVenda : BaseData, IItensVenda
    {
        public double? Quantidade { get; set; }
        public decimal? Valor { get; set; }

        public Guid VendaUid { get; set; }
        public Venda DbVenda { get; set; }
        public Guid ProdutoUid { get; set; }
        public Produto DbProduto { get; set; }
    }
}
