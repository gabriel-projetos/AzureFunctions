using Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Api.Service.Stock.Models
{
    public partial class Fornecedor : BaseData, IFornecedor
    {
        public Fornecedor()
        {
            DbComprasModel = new List<Compra>();
        }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Fone { get; set; }
        public string Cel { get; set; }
        public string Email { get; set; }
        public string EnderecoNumero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public virtual List<Compra> DbComprasModel { get; set; }
        public List<ICompra> Compras => new List<ICompra>(DbComprasModel);
    }
}
