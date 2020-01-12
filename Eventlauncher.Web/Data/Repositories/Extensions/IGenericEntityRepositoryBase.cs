using DaHo.Library.AspNetCore.Data.Repositories.Abstractions;
using System.Threading.Tasks;

namespace Eventlauncher.Web.Data.Repositories.Extensions
{
    public interface IGenericEntityRepositoryBase<TEntity> : IGenericRepository<TEntity>
    {
        Task<TEntity> CreateAsyncReturnId(TEntity entity);
    }
}
