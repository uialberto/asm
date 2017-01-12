using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Asm.Dominio.Apolo.UoW;

namespace Asm.Dominio.Apolo.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Guid InstanceId { get; }

        IUnitOfWork UnitOfWork { get; }

        void UnTrackEntity(TEntity item);

        #region Lectura

        TEntity Get(object primaryKey);

        TEntity Get(object primaryKey, params Expression<Func<TEntity, object>>[] includes);

        TEntityProjection GetProjection<TEntityProjection>(object primaryKey, Expression<Func<TEntity, TEntityProjection>> projection);

        TEntityProjection GetProjection<TEntityProjection>(object primaryKey, Expression<Func<TEntity, TEntityProjection>> projection,
            params Expression<Func<TEntity, object>>[] includes);

        bool Any(Expression<Func<TEntity, bool>> expression);

        bool All(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> Filtrar(Expression<Func<TEntity, bool>> condicion);

        IEnumerable<TEntity> GetPage<TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy,
           int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending);

        IEnumerable<TEntity> GetPage<TKProperty>(int pageIndex, int pageSize, Expression<Func<TEntity, TKProperty>> orderBy,
            bool ascending, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetPage<TOrderBy>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TOrderBy>> orderBy,
           int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending);

        IEnumerable<TEntity> GetPage<TKProperty>(Expression<Func<TEntity, bool>> filterExpression,
            int pageIndex, int pageSize,
            Expression<Func<TEntity, TKProperty>> orderBy,
            SortOrder sortOrder = SortOrder.Ascending,
            params Expression<Func<TEntity, object>>[] includes);

        List<TProjection> GetPage<TProjection, TOrderProperty>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TProjection>> proyection,
            int pageIndex, int pageSize, Expression<Func<TProjection, TOrderProperty>> orderBy, SortOrder sortOrder = SortOrder.Ascending);

        #endregion

        #region Persistencia

        void Add(TEntity entity);
        void Modify(TEntity entity);
        void Remove(object id);
        void Remove(TEntity entity);
        void Remove(Expression<Func<TEntity, bool>> expression);

        #endregion
    }
}
