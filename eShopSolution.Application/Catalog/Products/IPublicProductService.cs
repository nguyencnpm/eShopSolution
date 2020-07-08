using eShopSulution.ViewModels.Catalog.Products;
using eShopSulution.ViewModels.Catalog.Products.Public;
using eShopSulution.ViewModels.Common;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
