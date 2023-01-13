using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IVenda : IBaseModel
    {
        string Data { get; set; }
        string NumeroNotaFiscal { get; set; }
        string Desconto { get; set; }
        string Total { get; set; }
        Guid ClienteUid { get; set; }
    }
}
