using Store.G04.Shared.Dtos.Products;

namespace Store.G04.Services.Abstractions.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetAllProductsAsync(int? brandId, int? typeId, string? sort, string? search, int? pageIndex, int? pageSize);
        Task<ProductResponse> GetProductByIdAsync(int id);
        Task<IEnumerable<BrandTypeResponse>> GetAllBrandsAsync();
        Task<IEnumerable<BrandTypeResponse>> GetAllTypesAsync();

    }
}
