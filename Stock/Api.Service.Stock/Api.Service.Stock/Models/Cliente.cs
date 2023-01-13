using Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Api.Service.Stock.Models
{
    public partial class Cliente : BaseData, ICliente
    {
        public Cliente()
        {
            DbVendasModel = new List<Venda>();
        }

        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Fone { get; set; }
        public string Cel { get; set; }
        public string EnderecoNumero { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public List<IVenda> Vendas => new List<IVenda>(DbVendasModel);
        public List<Venda> DbVendasModel { get; set; }
    }
}
