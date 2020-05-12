using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Transactions;
using TesteHiper.Data.Entidade;

namespace TesteHiper.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DatabaseContext _context;
        private readonly DbSet<TEntity> _entities;
        string errorMessage = string.Empty;

        public IQueryable<TEntity> Table => _entities.AsQueryable();

        public Repository(DatabaseContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            using (var transaction = new TransactionScope())
            {
                _entities.Remove(entity);
                _context.SaveChanges();
                transaction.Complete();
            }
        }

        public virtual TEntity GetById(object id)
        {
            return _entities.FirstOrDefault(e => e.Id == Convert.ToInt32(id));
        }

        public virtual TEntity GetByGuid(string guid)
        {
            return _entities.FirstOrDefault(e => e.Guid.Equals(guid));
        }

        public virtual string Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (string.IsNullOrWhiteSpace(entity.Guid))
                entity.Guid = Guid.NewGuid().ToString();

            using (var transaction = new TransactionScope())
            {
                _entities.Add(entity);
                _context.SaveChanges();
                transaction.Complete();
            }

            return entity.Guid;
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            using (var transaction = new TransactionScope())
            {
                _entities.Update(entity);
                _context.SaveChanges();
                transaction.Complete();
            }
        }
    }
}
