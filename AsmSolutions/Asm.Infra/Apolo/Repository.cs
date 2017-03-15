using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Asm.Apolo.Dom.Repositories;
using Asm.Apolo.Dom.UoW;

namespace Asm.Infra.Apolo
{
    public abstract class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly EfUoW _unitOfWork;

        public Repository(IUnitOfWork context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (context is IEfUoW)
                _unitOfWork = context as EfUoW;
            InstanceId = Guid.NewGuid();
            if (_unitOfWork != null) _dbSet = _unitOfWork.CreateSet<TEntity>() as DbSet<TEntity>;
        }
        public Guid InstanceId { get; }

        public IUnitOfWork UnitOfWork => _unitOfWork;

        public virtual void Add(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
            }
        }
        public virtual void Modify(TEntity entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _unitOfWork.SetModified(entity);

            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
            }
        }
        public void UnTrackEntity(TEntity item)
        {
            var uOw = UnitOfWork as IObjectContextAdapter;
            uOw?.ObjectContext.Detach(item);
        }
        public virtual TEntity FirstOrDefault(object primaryKey)
        {
            try
            {
                var result = GetAll().Where("Id = @0", primaryKey).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw new Exception(message);
            }
        }
        public virtual TEntity Get(object primaryKey)
        {
            try
            {
                if (primaryKey != null)
                {
                    var result = FirstOrDefault(primaryKey);
                    return result;
                }
                else
                    return default(TEntity);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw new Exception(message);
            }
        }
        public TEntity Get(object primaryKey, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                if (primaryKey != null)
                {
                    var itemParameter = Expression.Parameter(typeof(TEntity));
                    var whereExpression = Expression.Lambda<Func<TEntity, bool>>
                        (Expression.Equal(Expression.Property(itemParameter, "Id"), Expression.Constant(primaryKey)),
                        new[] { itemParameter }
                        );
                    return GetSetAsQueryable(includes).Where(whereExpression).FirstOrDefault();
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Solo se puede incluir propiedades de Navegacion.");
            }
        }
        public virtual TEntityProjection GetProjection<TEntityProjection>(object primaryKey, Expression<Func<TEntity, TEntityProjection>> projection)
        {
            try
            {
                if (primaryKey != null)
                {
                    var result = GetAll().Where("Id = @0", primaryKey).Select(projection).FirstOrDefault();
                    return result;
                }
                else
                    return default(TEntityProjection);
            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
                throw new Exception(message);
            }
        }
        public virtual TEntityProjection GetProjection<TEntityProjection>(object primaryKey, Expression<Func<TEntity, TEntityProjection>> projection, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                if (primaryKey == null)
                    return default(TEntityProjection);
                else
                {
                    var itemParameter = Expression.Parameter(typeof(TEntity));
                    var whereExpression = Expression.Lambda<Func<TEntity, bool>>
                        (Expression.Equal(Expression.Property(itemParameter, "Id"), Expression.Constant(primaryKey)),
                            new[] { itemParameter }
                        );
                    return GetSetAsQueryable(includes).Where(whereExpression).Select(projection).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Solo se puede incluir propiedades de Navegacion.");
            }
        }
        public bool Any(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = _dbSet.Any(expression);
                return result;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw new Exception(message);
            }
        }
        public bool All(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = _dbSet.All(expression);
                return result;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw new Exception(message);
            }
        }
        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = GetSetAsQueryable(includes);
            return query;
        }
        IQueryable<TEntity> GetSetAsQueryable(params Expression<Func<TEntity, object>>[] includes)
        {
            var result = _dbSet.AsQueryable();
            return includes == null ? result : includes.Where(includeItem => includeItem != null)
                                                .Aggregate(result, (current, includeItem) => current.Include(includeItem));
        }
        public void Remove(object primaryKey)
        {
            try
            {
                var entity = _dbSet.Find(primaryKey);
                if (entity != null) Remove(entity);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw new Exception(message);
            }
        }
        public void Remove(TEntity entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw new Exception(message);
            }
        }
        public void Remove(Expression<Func<TEntity, bool>> expression)
        {
            foreach (var entity in _dbSet.Where(expression).ToList())
            {
                Remove(entity);
            }
        }
        public virtual IEnumerable<TEntity> GetPage<TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy,
           int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 1;

            if (sortOrder == SortOrder.Ascending)
            {
                return GetAll().OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
            }
            return GetAll().OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
        }
        public virtual IQueryable<TEntity> Filtrar(Expression<Func<TEntity, bool>> filterExpression)
        {
            return GetAll().Where(filterExpression);
        }

        public virtual IEnumerable<TEntity> GetPage<TOrderBy>(Expression<Func<TEntity, bool>> filterExpression,
            Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 1;
            if (sortOrder == SortOrder.Ascending)
            {
                return Filtrar(filterExpression)
                       .OrderBy(orderBy)
                       .Skip((pageIndex - 1) * pageSize)
                       .Take(pageSize).AsEnumerable();
            }
            return Filtrar(filterExpression)
                    .OrderByDescending(orderBy)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize).AsEnumerable();
        }
        public virtual IEnumerable<TEntity> GetPage<TKProperty>(int pageIndex, int pageSize, Expression<Func<TEntity, TKProperty>> orderBy,
                                                                    bool ascending, params Expression<Func<TEntity, object>>[] includes)
        {
            var set = GetSetAsQueryable(includes);
            if (ascending)
            {
                return set.OrderBy(orderBy)
                          .Skip(pageSize * pageIndex)
                          .Take(pageSize).AsEnumerable();
            }
            else
            {
                return set.OrderByDescending(orderBy)
                          .Skip(pageSize * pageIndex)
                          .Take(pageSize).AsEnumerable();
            }
        }
        public virtual IEnumerable<TEntity> GetPage<TKProperty>(Expression<Func<TEntity, bool>> filterExpression, int pageIndex, int pageSize,
            Expression<Func<TEntity, TKProperty>> orderBy, SortOrder sortOrder = SortOrder.Ascending, params Expression<Func<TEntity, object>>[] includes)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 1;
            if (sortOrder == SortOrder.Ascending)
            {
                var res1 = GetAll(includes).Where(filterExpression)
                        .OrderBy(orderBy)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).AsEnumerable();
                return res1;
            }
            var res = GetAll(includes).Where(filterExpression)
                       .OrderByDescending(orderBy)
                       .Skip((pageIndex - 1) * pageSize)
                       .Take(pageSize).AsEnumerable();
            return res;
        }

        public virtual List<TProjection> GetPage<TProjection, TOrderProperty>
        (Expression<Func<TEntity, bool>> filterExpression,
         Expression<Func<TEntity, TProjection>> proyection,
         int pageIndex, int pageSize,
         Expression<Func<TProjection, TOrderProperty>> orderBy,
         SortOrder sortOrder = SortOrder.Ascending)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 1;
            if (sortOrder == SortOrder.Ascending)
            {
                var res1 = GetAll().Where(filterExpression)
                                   .Select(proyection)
                                   .OrderBy(orderBy)
                                   .Skip((pageIndex - 1) * pageSize)
                                   .Take(pageSize).ToList();
                return res1;
            }
            var res = GetAll().Where(filterExpression)
                              .Select(proyection)
                              .OrderByDescending(orderBy)
                              .Skip((pageIndex - 1) * pageSize)
                              .Take(pageSize).ToList();
            return res;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }


    }
}
