using DaHo.Library.AspNetCore.Data.Repositories.EntityFramework;
using Eventlauncher.Web.Data.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Eventlauncher.Web.Data.Extensions
{
    public class GenericEntityRepositoryBase<TEntity, TContext> : GenericEntityRepository<TEntity, TContext>, IGenericEntityRepositoryBase<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext Context;
        protected GenericEntityRepositoryBase(TContext context) : base(context)
        {
            Context = context;
        }

        public virtual async Task<TEntity> CreateAsyncReturnId(TEntity entity)
        {
            await Context.Set<TEntity>()
                .AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
