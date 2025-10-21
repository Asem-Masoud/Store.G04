using AutoMapper;
using Store.G04.Domain.Contracts;
using Store.G04.Domain.Entities.Products;
using Store.G04.Services.Abstractions.Products;
using Store.G04.Shared.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Services.Products
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
        {
            var Products = await _unitOfWork.GetRepository<int, Product>().GetAllAsync();
            var result = _mapper.Map<IEnumerable<ProductResponse>>(Products);
            return result;
        }

        public async Task<ProductResponse> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.GetRepository<int, Product>().GetAsync(id);
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