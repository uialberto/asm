using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Dominio.Apolo.Repositories;
using Asm.Dominio.Modulos.Core.Agregados.AsmAgentes;
using Asm.Dominio.Modulos.Core.Agregados.Mascotas;
using Asm.Infra.Modulos.Core.Repositorios;

namespace Asm.Infra.Test.Helpers.Modulos.Core
{
    public class RepoMascotasHelperTest
    {
        public static IRepoMascotas CreateRepository()
        {
            return new RepoMascotas(UnitOfWorkTestUtils.GetUnitOfWork());
        }
        public static Mascota Create()
        {
            var repo = CreateRepository();
            var entity = Get();
            var unitOfWork = repo.UnitOfWork;
            repo.Add(entity);
            unitOfWork.SaveChanges();
            return entity;
        }
        public static Mascota Create(Mascota dto)
        {
            var repo = CreateRepository();
            var entity = dto;
            var unitOfWork = repo.UnitOfWork;
            repo.Add(entity);
            unitOfWork.SaveChanges();
            return entity;
        }
        public static Mascota Get()
        {
            var result = new Mascota()
            {
                Id = (long)UtilitariosBase.NextLongId<Mascota, long, IRepository<Mascota>>(CreateRepository), // ToDo Opcional
                Nombre = UtilitariosBase.NewGuid(),
                FechaCreacion = DateTime.UtcNow,
                KeyEstado = UtilitariosBase.NewGuid().Substring(0,3),
                KeyTipoAnimal = UtilitariosBase.NewGuid().Substring(0,3),
                Direccion = UtilitariosBase.NewGuid(),
                KeyTamanio = UtilitariosBase.NewGuid().Substring(0,3),
                AsmAgente = RepoAsmAgentesHelperTest.Get()
                // Otras propiedades requeridas....
            };
            return result;
        }
    }
}
