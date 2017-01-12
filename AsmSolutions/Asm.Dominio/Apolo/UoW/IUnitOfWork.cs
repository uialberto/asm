using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm.Dominio.Apolo.UoW
{
    public interface IUnitOfWork
    {
        Guid InstanceId { get; }
        int SaveChanges();
        void RollbackChanges();
    }
}
