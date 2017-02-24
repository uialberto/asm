using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Dtos.DataTransfers;
using Asm.Aplicacion.Helpers.Security;
using Asm.Dominio.Modulos.Core.Agregados.AsmAgentes;
using Asm.Infra.Apolo;
using AutoMapper.QueryableExtensions;

namespace Asm.Aplicacion.Modulos.Core.AsmAgentes.Impl
{
    public class AppServiceAsmAgentes : IAppServiceAsmAgentes
    {
        protected readonly IRepoAsmAgentes Repository;

        #region Constructor

        public AppServiceAsmAgentes(IRepoAsmAgentes pRepository)
        {
            if (pRepository == null)
                throw new ArgumentNullException(nameof(pRepository));

            Repository = pRepository;
        }

        #endregion

        public AsmAgenteDto Obtener(AsmAgenteDto dto)
        {
            AsmAgenteDto result = null;
            try
            {
                #region Validaciones

                if (string.IsNullOrWhiteSpace(dto?.Id))
                {
                    return result;
                }

                #endregion

                #region Proceso

                var entity = Repository.Get(dto.Id); ;
                if (entity != null)
                {
                    var entityDto = new AsmAgenteDto()
                    {
                        Id = entity.Id,
                        Nombres = entity.Nombres,
                        Apellidos = entity.Apellidos,
                        Celular = entity.Celular,
                        Direccion = entity.Direccion,
                        Telefono = entity.Telefono,
                        UserId = entity.UserId
                    };
                    result = entityDto;
                    return result;
                }

                #endregion

            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
            }

            return result;
        }

        public int Crear(AsmAgenteDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
