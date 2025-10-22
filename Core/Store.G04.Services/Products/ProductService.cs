using AutoMapper;
using Store.G04.Domain.Contracts;
using Store.G04.Domain.Entities.Products;
using Store.G04.Services.Abstractions.Products;
using Store.G04.Services.Specifications.Products;
using Store.G04.Shared.Dtos.Products;

namespace Store.G04.Services.Products
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
        {
            /*
            // Apply Specifications to Include Related Data
            var spec = new Specifications.BaseSpecifications<int, Product>(null);
            spec.Includes.Add(p => p.Brand);
            spec.Includes.Add(p => p.Type);
            */

            var spec = new ProductsWithBrandAndTypeSpecification();
            // Get All Products Through ProductRepository
            // var Products = await _unitOfWork.GetRepository<int, Product>().GetAllAsync();
            var Products = await _unitOfWork.GetRepository<int, Product>().GetAllAsync(spec); // Apply Specifications

            //Mapping IEnumerable<Product> To IEnumerable<ProductResponse> Using AutoMapper
            var result = _mapper.Map<IEnumerable<ProductResponse>>(Products);
            return result;
        }

        public async Task<ProductResponse> GetProductByIdAsync(int id)
        {
            var spec = new ProductsWithBrandAndTypeSpecification(id); // Apply Specifications

            //var product = await _unitOfWork.GetRepository<int, Product>().GetAsync(id);
            var product = await _unitOfWork.GetRepository<int, Product>().GetAsync(spec); // Apply Specifications
            var result = _mapper.Map<ProductResponse>(product);
            return result;
        }

        public async Task<IEnumerable<BrandTypeResponse>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.GetRepository<int, ProductBrand>().GetAllAsync();
            var result = _mapper.Map<IEnumerable<BrandTypeResponse>>(brands);
            return result;
        }

        public async Task<IEnumerable<BrandTypeResponse>> GetAllTypesAsync()
        {
            var Types = await _unitOfWork.GetRepository<int, ProductType>().GetAllAsync();
            var result = _mapper.Map<IEnumerable<BrandTypeResponse>>(Types);
            return result;
        }
    }
}