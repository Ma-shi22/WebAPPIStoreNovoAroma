namespace Entities.SearchFilters
{
    public interface IProductoFilter
    {
        DateTime? InsertDateFrom { get; set; }
        DateTime? InsertDateTo { get; set; }
        bool IsActive { get; set; }
        string? Marca { get; set; }
        int? PrecioDesde { get; set; }
       int? PrecioHasta { get; set; }
        
    }
}