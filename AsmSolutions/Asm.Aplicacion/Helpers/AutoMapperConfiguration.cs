using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Asm.Aplicacion.Helpers
{
    public static class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            ConfigureBase();
        }

        private static void ConfigureBase()
        {
            Mapper.Initialize(config =>
           {
               config.CreateMap<Dominio.Modulos.Core.Agregados.Mascotas.Mascota, Dtos.DataTransfers.MascotaDto>()
                   .ForMember(dto => dto.AsmAgenteId, opt => opt.MapFrom(entity => entity.AsmAgente.Id));

               config.CreateMap<Dominio.Modulos.Core.Agregados.AsmAgentes.AsmAgente, Dtos.DataTransfers.AsmAgenteDto>()
                   .ForMember(dto => dto.UserId, opt => opt.MapFrom(entity => entity.UserId));
           });


        }
    }
}
