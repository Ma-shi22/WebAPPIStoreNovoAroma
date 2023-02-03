using Data;
using WebAPPIStoreNovoAroma;
using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class ProductoLogic
    {
        private readonly ServiceContext _serviceContext;
        public ProductoLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public int InsertProducto(Producto productoItem)
        {
            _serviceContext.Productos.Add(productoItem);
            _serviceContext.SaveChanges();
            return productoItem.Id;
        }

        public void UpdateProducto(Producto productoItem)
        {
            _serviceContext.Productos.Update(productoItem);

            _serviceContext.SaveChanges();
        }

        public void DeleteProducto(int id)
        {
            var productoToDelete = _serviceContext.Set<Producto>()
                 .Where(u => u.Id == id).First();

            productoToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }

        public void DeleteProductoMarca(string Marca)
        {
            var productoMarcaToDelete = _serviceContext.Set<Producto>()
                 .Where(u => u.Marca == Marca).First();

            productoMarcaToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }

        public List<Producto> GetAllProductos()
        {
            return _serviceContext.Set<Producto>().ToList();
        }

        public List<Producto> GetProductosByCriteria(ProductoFilter productoFilter)
        {
            var resultList = _serviceContext.Set<Producto>()
                                        .Where(u => u.IsActive == true);

            //.Where(u => u.Marca = productoFilter.Marca);

           // if (productoFilter.InsertDateFrom != null)
            {
               // resultList = resultList.Where(u => u.InsertDate > productoFilter.InsertDateFrom);
            }

           // if (productoFilter.InsertDateTo != null)
            {
              //  resultList = resultList.Where(u => u.InsertDate < productoFilter.InsertDateTo);
            }
           // if (productoFilter.PrecioDesde != null)
            {
               // resultList = resultList.Where(u => u.Precio > productoFilter.PrecioDesde);
            }

           // if (productoFilter.PrecioHasta != null)
            {
             //   resultList = resultList.Where(u => u.Precio < productoFilter.PrecioHasta);
            }

            return resultList.ToList();
        }



    }
}


