using Store.G04.Domain.Entities.Products;

namespace Store.G04.Services.Specifications.Products
{
    public class ProductsWithBrandAndTypeSpecification : BaseSpecifications<int, Product>
    {
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
        public ProductsWithBrandAndTypeSpecification(int? brandId, int? typeId, string? sort, string? search, int? pageIndex, int? pageSize) : base
            (
            P =>
            (!brandId.HasValue || P.BrandId == brandId)
            &&
            (!typeId.HasValue || P.TypeId == typeId)
            &&
            (string.IsNullOrEmpty(search) || P.Name.ToLower().Contains(search.ToLower()))
            )

        {
            // Paging
            // PageSize = 5
            // PageIndex = 3
            // Skip: 2 +5 (PageIndex-1) * pageSize

            // Take : 5
            ApplyPagination(pageSize.Value, pageIndex.Value);

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
            ApplySorting(sort);
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