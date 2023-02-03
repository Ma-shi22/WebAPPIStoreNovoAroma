using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public DateTime FechaPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoCliente { get; set; }

        public int IdProducto { get; set; }
        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal ImporteTotal { get; set; }

        public DateTime FechaEntrega { get; set; }
        public bool Pagado { get; set; }
        public bool Entregado { get; set; }
        public bool IsActive { get; set; }
    }
}