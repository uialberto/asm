using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Apolo.Services;
using Asm.Aplicacion.Dtos.DataTransfers;
using Asm.Aplicacion.Helpers;
using Asm.Dominio.Modulos.Core.Agregados.Mascotas;
using Asm.Infra;
using AutoMapper.QueryableExtensions;

namespace Asm.Aplicacion.Modulos.Core.Mascotas.Impl
{
    public class AppServiceMascotas : IAppServiceMascotas
    {
        protected readonly IRepoMascotas Repository;

        #region Constructor

        public AppServiceMascotas(IRepoMascotas pRepository)
        {
            if (pRepository == null)
                throw new ArgumentNullException(nameof(pRepository));

            Repository = pRepository;
        }
        public List<MascotaDto> MascotasOlvidadas()
        {
            var result = new List<MascotaDto>();
            try
            {
                var list = Repository.Filtrar(ele => ele.KeyEstado.ToUpper() == Mascota.KeyEstadoPendiente)
                                     .ProjectTo<MascotaDto>(AutoMapperConfiguration.AutoMappConfig).ToList();
                result = list;
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                // ToDo Pendiente catch para control de excepciones...
            }
            return result;
        }

        #endregion
    }
}
