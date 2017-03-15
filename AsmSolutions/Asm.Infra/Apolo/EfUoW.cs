using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Apolo.Dom.UoW;

namespace Asm.Infra.Apolo
{
    public abstract class EfUoW : DbContext, IUnitOfWork, IEfUoW
    {
        private bool _disposed;
        public Guid InstanceId { get; }
        public EfUoW(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            InstanceId = Guid.NewGuid();
        }
        protected EfUoW(DbConnection connection)
            : base(connection, true)
        {
            InstanceId = Guid.NewGuid();
        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(builder);
        }
        public virtual IDbSet<TEntidad> CreateSet<TEntidad>() where TEntidad : class
        {
            return Set<TEntidad>();
        }
        public virtual void Attach<TEntidad>(TEntidad item) where TEntidad : class
        {
            Entry(item).State = EntityState.Unchanged;

        }
        public virtual void SetModified<TEntidad>(TEntidad item) where TEntidad : class
        {
            Entry(item).State = EntityState.Modified;
        }
        public override int SaveChanges()
        {
            var changes = base.SaveChanges();
            return changes;
        }
        protected override void Dispose(bool disposing)
        {
            _disposed = disposing;
            if (_disposed)
            {
                return;
            }
            base.Dispose(_disposed);
        }
        public void RollbackChanges()
        {
            ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Unchanged);
        }
    }
}
