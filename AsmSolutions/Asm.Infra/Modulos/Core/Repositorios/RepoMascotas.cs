using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Dominio.Apolo.UoW;
using Asm.Dominio.Modulos.Core.Agregados.Mascotas;
using Asm.Infra.Apolo;

namespace Asm.Infra.Modulos.Core.Repositorios
{

    public partial class RepoMascotas : Repository<Mascota>, IRepoMascotas
    {
        public RepoMascotas(IUnitOfWork context) : base(context)
        {
        }
    }
}
