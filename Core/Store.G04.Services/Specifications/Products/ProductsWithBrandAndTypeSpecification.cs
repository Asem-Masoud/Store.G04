using Store.G04.Domain.Entities.Products;
using Store.G04.Shared.Dtos.Products;

namespace Store.G04.Services.Specifications.Products
{
    public class ProductsWithBrandAndTypeSpecification : BaseSpecifications<int, Product>
    {
        //
        //public ProductsWithBrandAndTypeSpecification(Expression<Func<Product, bool>>? expression) : base(expression)
        //{
        //    Includes.Add(p => p.Brand);
        //    Includes.Add(p => p.Type);
        //}
        public ProductsWithBrandAndTypeSpecification(int id) : base(P => P.Id == id)
        {
            ApplyIncludes();
        }

        // null & null
        public ProductsWithBrandAndTypeSpecification(ProductQueryParameters parameters) : base
            (
            P =>
            (!parameters.BrandId.HasValue || P.BrandId == parameters.BrandId)
            &&
            (!parameters.TypeId.HasValue || P.TypeId == parameters.TypeId)
            &&
            (string.IsNullOrEmpty(parameters.Search) || P.Name.ToLower().Contains(parameters.Search.ToLower()))
            )

        {
            // Paging
            // PageSize = 5
            // PageIndex = 3
            // Skip: 2 +5 (PageIndex-1) * pageSize

            // Take : 5
            ApplyPagination(parameters.PageSize, parameters.PageIndex);

            // Sorting
            /*
              if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    case "priceasc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "pricedesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
            else
            {
                AddOrderBy(p => p.Name);
            }
            */
            ApplySorting(parameters.Sort);
            ApplyIncludes();
        }

        private void ApplySorting(string? sort)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    case "priceasc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "pricedesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
            else
            {
                AddOrderBy(p => p.Name);
            }
        }

        private void ApplyIncludes()
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Type);
        }

    }
}