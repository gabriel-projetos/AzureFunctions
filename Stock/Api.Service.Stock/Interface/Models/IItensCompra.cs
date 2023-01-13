using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IItensCompra : IBaseModel
    {
        double? Quantidade { get; set; }
        decimal? Valor { get; set; }
    }
}
