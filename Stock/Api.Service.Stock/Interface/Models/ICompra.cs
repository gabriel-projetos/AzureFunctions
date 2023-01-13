using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface ICompra : IBaseModel
    {
        DateTime? Data { get; set; }
        int? NumeroNotaFiscal { get; set; }
        decimal? Total { get; set; }
        List<IItensCompra> ItensCompras { get; }
    }
}
