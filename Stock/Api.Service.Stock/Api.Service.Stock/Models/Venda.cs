using Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Api.Service.Stock.Models
{
    public partial class Venda : BaseData, IVenda
    {
        public Venda()
        {
            DbItensVendasModel = new List<ItensVenda>();
        }

        public string Data { get; set; }
        public string NumeroNotaFiscal { get; set; }
        public string Desconto { get; set; }
        public string Total { get; set; }
        public virtual Guid ClienteUid { get; set; }
        public virtual Cliente DbCliente { get; set; }
        public virtual Guid? TipoPagamentoUid { get; set; }
        public virtual TipoPagamento DbTipoPagamento { get; set; }

        public List<ItensVenda> DbItensVendasModel { get; set; }

        public List<IItensVenda> ItensVendas => new List<IItensVenda>(DbItensVendasModel);

    }
}
