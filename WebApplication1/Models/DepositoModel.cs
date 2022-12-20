using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DepositoModel
    {
        public int IdSucursal { get; set; }
        public int IdDeposito { get; set; }
        public string Nombre_articulo { get; set; }
        public string Cantidad { get; set; }
    }
}
