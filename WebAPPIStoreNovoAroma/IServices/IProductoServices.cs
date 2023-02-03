using Entities.Entities;
using Entities.SearchFilters;

namespace WebAPPIStoreNovoAroma.IServices
{
    public interface IProductoServices
    {
        int InsertProducto(Producto producto);
        void UpdateProducto(Producto producto);
        void DeleteProducto(int id);
        List<Producto> GetAllProductos();
        List<Producto> GetProductosByCriteria(ProductoFilter productoFilter);
    }
}