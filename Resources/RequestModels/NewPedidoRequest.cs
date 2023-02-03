using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.RequestModels
{
    public class NewPedidoRequest
    {

        public DateTime FechaPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoCliente { get; set; }

        public int IdProducto { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
        public decimal Descuento { get; private set; }
        public decimal ImporteTotal { get; private set; }

        public DateTime FechaEntrega { get; set; }
        public bool Pagado { get; set; }
        public bool Entregado { get; set; }
        public bool IsActive { get; set; }

        public Pedido ToPedido(Pedido pedido)
        {
            var pedidoItem = new Pedido();

            pedidoItem.FechaPedido = FechaPedido;
            pedidoItem.IdProducto = IdProducto;
            pedidoItem.IdCliente = IdCliente;
            pedidoItem.IdTipoCliente = IdTipoCliente;
            pedidoItem.Cantidad = Cantidad;
            pedidoItem.Precio = Precio;
            if (pedidoItem.IdTipoCliente == 1)
            {
                pedidoItem.Descuento = (10 * (Cantidad * Precio)) / 100;
            }
            if (pedidoItem.IdTipoCliente == 2)
            {
                pedidoItem.Descuento = (15 * (Cantidad * Precio)) / 100;
            }
            if (pedidoItem.IdTipoCliente == 3)
            {
                pedidoItem.Descuento = (20 * (Cantidad * Precio)) / 100;
            }
            else
            {
                pedidoItem.Descuento = 0;
            }

            if (pedidoItem.IdTipoCliente == 1)
            {
                pedidoItem.ImporteTotal = (90 * (Cantidad * Precio)) / 100;
            }
            if (pedidoItem.IdTipoCliente == 2)
            {
                pedidoItem.ImporteTotal = (85 * (Cantidad * Precio)) / 100;
            }
            if (pedidoItem.IdTipoCliente == 3)
            {
                pedidoItem.ImporteTotal = (80 * (Cantidad * Precio)) / 100;
            }
            else
            {
                pedidoItem.ImporteTotal = Cantidad * Precio;
            }

            pedidoItem.FechaEntrega = FechaEntrega;
            pedidoItem.Pagado = Pagado;
            pedidoItem.Entregado = Entregado;
            pedidoItem.IsActive = true;

            return pedido;
        }
    }
}
