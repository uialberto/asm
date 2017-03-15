using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Apolo.Dom.UoW;
using Asm.Dominio.Modulos.Core.Agregados.AsmAgentes;
using Asm.Dominio.Modulos.Core.Agregados.ClientesApi;

namespace Asm.Infra.Modulos.Core.Repositorios
{

    public partial class RepoClientesApi : RepositoryIdentity<ClienteApi>, IRepoClientesApi
    {
        public RepoClientesApi(IUnitOfWork context) : base(context)
        {
        }
    }
}
