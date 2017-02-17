using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Dominio.Modulos.Core.Agregados.AsmAgentes;
using Asm.Dominio.Modulos.Seguridad.Agregados.AppUsers;
using Asm.Infra.Modulos.Core.Repositorios;
using Microsoft.AspNet.Identity;

namespace Asm.Infra.Test.Helpers.Modulos.Core
{
    public class RepoAsmAgentesHelperTest
    {
        public static IRepoAsmAgentes CreateRepository()
        {
            return new RepoAsmAgentes(UnitOfWorkTestUtils.GetUnitOfWork());
        }
        public static AsmAgente Create()
        {
            var repo = CreateRepository();
            var entity = Get();
            var unitOfWork = repo.UnitOfWork;
            repo.Add(entity);
            unitOfWork.SaveChanges();
            return entity;
        }
        public static AsmAgente Create(AsmAgente dto)
        {
            var repo = CreateRepository();
            var entity = dto;
            var unitOfWork = repo.UnitOfWork;
            repo.Add(entity);
            unitOfWork.SaveChanges();
            return entity;
        }
        public static AsmAgente Get()
        {
            var result = new AsmAgente()
            {
                Id = UtilitariosBase.NewGuid(),
                Nombres = UtilitariosBase.NewGuid(),
                User = new AppUser()
                {
                    Id = UtilitariosBase.NewGuid().Substring(10),
                    UserName = UtilitariosBase.NewGuid().Substring(8),
                    PasswordHash = new PasswordHasher().HashPassword("uibasoft"),
                    Email = UtilitariosBase.NewGuid().Substring(5) + "@uibasoft.com"

                }
                // Otras propiedades requeridas...
            };
            return result;
        }
    }
}
