﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Dominio.Modulos.Core.Agregados.ClientesApi;

namespace Asm.Infra.Modulos.Core.Mapping.ClientesApi
{

    public partial class ClienteApiConfig : EntityTypeConfiguration<ClienteApi>
    {
        public ClienteApiConfig()
        {
            Configure();
        }

        public virtual void Configure()
        {
            HasKey(e => e.Id);
            ToTable("core.ClientesApi");

            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Propiedades escalares
            Property(e => e.Id).HasColumnName("IdClienteApi");

            Property(e => e.Nombre).IsRequired();
            Property(e => e.Nombre).HasColumnName("Nombre");
            Property(e => e.Nombre).HasMaxLength(300);

            Property(e => e.Descripcion).IsOptional();
            Property(e => e.Descripcion).HasColumnName("Descripcion");
            Property(e => e.Descripcion).HasMaxLength(300);


            Property(e => e.ApiCliente).IsRequired();
            Property(e => e.ApiCliente).HasColumnName("ApiClient");
            Property(e => e.ApiCliente).HasMaxLength(200);


            Property(e => e.ApiSecret).IsRequired();
            Property(e => e.ApiSecret).HasColumnName("ApiSecret");
            Property(e => e.ApiSecret).HasMaxLength(200);

            Property(e => e.Active).IsRequired();
            Property(e => e.Active).HasColumnName("Activo");

            Property(e => e.Tipo).IsRequired();
            Property(e => e.Tipo).HasColumnName("KeyTipoApi");

            Property(e => e.PermiteOrigin).IsOptional();
            Property(e => e.PermiteOrigin).HasColumnName("PermiteOrigina");
            Property(e => e.PermiteOrigin).HasMaxLength(100);

            Property(e => e.FechaCreacion).IsRequired();
            Property(e => e.FechaCreacion).HasColumnName("FechaCreacion");

        }
    }
}
