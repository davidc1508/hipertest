using System.Collections.Generic;
using System.Linq;
using TesteHiper.Data.Entidade;

namespace TesteHiper.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Table { get; }

        TEntity GetById(object id);
        TEntity GetByGuid(string guid);
        string Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
