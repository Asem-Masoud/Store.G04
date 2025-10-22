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

        public ProductsWithBrandAndTypeSpecification() : base(null)
        {
            ApplyIncludes();
        }

        private void ApplyIncludes()
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Type);
        }
    }
}