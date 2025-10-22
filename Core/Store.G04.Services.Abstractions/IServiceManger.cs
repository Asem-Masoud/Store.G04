using Store.G04.Services.Abstractions.Products;

namespace Store.G04.Services.Abstractions
{
    public interface IServiceManger
    {
        IProductService ProductService { get; }
    }
}
