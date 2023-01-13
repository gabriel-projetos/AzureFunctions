using Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Api.Service.Stock.Models
{
    public partial class TipoPagamento : BaseData, ITipoPagamento
    {
        public TipoPagamento()
        {
            DbComprasModel = new List<Compra>();
            DbVendasModel = new List<Venda>();
        }

        public string Nome { get; set; }

        public virtual List<ICompra> Compras => new List<ICompra>(DbComprasModel);
        public List<Compra> DbComprasModel { get; set; }

        public virtual List<IVenda> Vendas => new List<IVenda>(DbVendasModel);

        public List<Venda> DbVendasModel { get; set; }

        public RoleType RolesCanRead { get; set; }

        internal object Select(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
