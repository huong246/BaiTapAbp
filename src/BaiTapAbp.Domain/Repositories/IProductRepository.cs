using BaiTapAbp.Entities;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace BaiTapAbp.Repositories;

public interface IProductRepository : IRepository<ProductEntity, int>, IScopedDependency
{
    
    
}