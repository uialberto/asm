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
        private static MapperConfiguration _config;
        public static void Initialize()
        {
            ConfigureBase();
        }

        private static void ConfigureBase()
        {
            if (_config == null)
            {
                _config = GetMapperBase();
            }
        }

        private static MapperConfiguration GetMapperBase()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Dominio.Modulos.Core.Agregados.Mascotas.Mascota, Dtos.DataTransfers.MascotaDto>()
                    .ForMember(dto => dto.AsmAgenteId, opt => opt.MapFrom(entity => entity.AsmAgente.Id));

                config.CreateMap<Dominio.Modulos.Core.Agregados.AsmAgentes.AsmAgente, Dtos.DataTransfers.AsmAgenteDto>()
                    .ForMember(dto => dto.UserId, opt => opt.MapFrom(entity => entity.UserId));

            });
        }

        public static MapperConfiguration AutoMappConfig => _config ?? (_config = GetMapperBase());
    }
}
