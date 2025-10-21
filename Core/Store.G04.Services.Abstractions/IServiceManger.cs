using Store.G04.Services.Abstractions.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Services.Abstractions
{
    public interface IServiceManger
    {
        IProductService ProductService { get; }
    }
}
