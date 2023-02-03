using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IProductoLogic
    {
        int InsertProducto(Producto productoItem);
        void UpdateProducto(Producto productoItem);
        void DeleteProducto(int id);
        void DeleteProductoMarca(string Marca);
        List<Producto> GetAllProductos();
        List<Producto> GetProductosByCriteria(ProductoFilter productoFilter);
    }
}

