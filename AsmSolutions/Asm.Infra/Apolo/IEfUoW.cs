using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Dominio.Apolo.UoW;

namespace Asm.Infra.Apolo
{
    public interface IEfUoW : IUnitOfWork
    {
        IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class;
        void Attach<TEntity>(TEntity item) where TEntity : class;
        void SetModified<TEntity>(TEntity item) where TEntity : class;
    }
}
