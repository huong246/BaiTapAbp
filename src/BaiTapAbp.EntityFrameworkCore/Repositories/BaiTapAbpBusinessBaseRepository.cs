using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BaiTapAbp.EntityFrameworkCore;
using Dapper;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BaiTapAbp.Repositories;

public class BaiTapAbpBusinessBaseRepository<TEntity, Tkey>(
    IDbContextProvider<BaiTapAbpBusinessDbContext> dbContextProvider)
    : EfCoreRepository<BaiTapAbpBusinessDbContext, TEntity, Tkey>(dbContextProvider)
    where TEntity : class, IEntity<Tkey>
{
    protected async Task<int> ExecuteAsync(string sql, object? param = null, CommandType? commandType = null)
    {
        var dbConnection = await GetDbConnectionAsync();
        var transaction = await GetDbTransactionAsync();
        return (await dbConnection.ExecuteAsync(sql, param, transaction: transaction));
    }

    protected async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? param = null,
        CommandType? commandType = null)
    {
        var dbConnection = await GetDbConnectionAsync();
        var transaction = await GetDbTransactionAsync();
        return (await dbConnection.QueryFirstOrDefaultAsync<T>(sql, param, transaction: transaction)!);
    }

    protected async Task<IEnumerable<T>> QueryListAsync<T>(string sql, object? param = null,
        CommandType? commandType = null)
    {
        var dbConnection = await GetDbConnectionAsync();
        var transaction = await GetDbTransactionAsync();
        return (await dbConnection.QueryAsync<T>(sql, param, transaction: transaction));
    }
}
