using Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Api.Service.Stock.Models
{
    public partial class Compra : BaseData, ICompra
    {
        public Compra()
        {
            DbItensCompraModel = new List<ItensCompra>();
        }

        public DateTime? Data { get; set; }
        public int? NumeroNotaFiscal { get; set; }
        public decimal? Total { get; set; }
        
        public Guid? FornecedorUid { get; set; }
        public virtual Fornecedor DbFornecedorModel { get; set; }
        
        public Guid? TipoPagamentoUid { get; set; }

        public virtual TipoPagamento DbTipoPagamentoModel { get; set; }
        
        public virtual List<ItensCompra> DbItensCompraModel { get; set; }
        public List<IItensCompra> ItensCompras => new List<IItensCompra>(DbItensCompraModel);
    }
}
