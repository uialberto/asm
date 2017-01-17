using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Dominio.Modulos.Core.Agregados.Mascotas;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asm.Infra.Modulos.Core.Mapping.Mascotas
{
    public partial class MascotaConfig : EntityTypeConfiguration<Mascota>
    {
        public MascotaConfig()
        {
            Configure();
        }

        public virtual void Configure()
        {
            HasKey(e => e.Id);
            ToTable("core.Mascotas");

            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Propiedades escalares
            Property(e => e.Id).HasColumnName("IdMascota");

            Property(e => e.Nombre).IsRequired();
            Property(e => e.Nombre).HasColumnName("Nombre");
            Property(e => e.Nombre).HasMaxLength(50);

            Property(e => e.Descripcion).IsOptional();
            Property(e => e.Descripcion).HasColumnName("Descripcion");
            Property(e => e.Descripcion).HasMaxLength(500);


            Property(e => e.Nacimiento).IsOptional();
            Property(e => e.Nacimiento).HasColumnName("Nacimiento");

            Property(e => e.EsMacho).IsOptional();
            Property(e => e.EsMacho).HasColumnName("EsMacho");

            Property(e => e.Raza).IsOptional();
            Property(e => e.Raza).HasColumnName("Raza");
            Property(e => e.Raza).HasMaxLength(30);

            Property(e => e.Longitud).IsOptional();
            Property(e => e.Longitud).HasColumnName("Longitud");
            Property(e => e.Longitud).HasPrecision(12, 4);

            Property(e => e.Latitud).IsOptional();
            Property(e => e.Latitud).HasColumnName("Latitud");
            Property(e => e.Latitud).HasPrecision(12, 4);

            Property(e => e.KeyColor).IsOptional();
            Property(e => e.KeyColor).HasColumnName("KeyColor");
            Property(e => e.KeyColor).HasMaxLength(20);


            Property(e => e.FechaCreacion).IsRequired();
            Property(e => e.FechaCreacion).HasColumnName("FechaCreacion");


            Property(e => e.KeyEstado).IsRequired();
            Property(e => e.KeyEstado).HasColumnName("KeyEstado");
            Property(e => e.KeyEstado).HasMaxLength(5);

            Property(e => e.KeyTipoAnimal).IsRequired();
            Property(e => e.KeyTipoAnimal).HasColumnName("KeyTipoAnimal");
            Property(e => e.KeyTipoAnimal).HasMaxLength(5);

            Property(e => e.Direccion).IsRequired();
            Property(e => e.Direccion).HasColumnName("Direccion");
            Property(e => e.Direccion).HasMaxLength(350);

            Property(e => e.KeyTamanio).IsRequired();
            Property(e => e.KeyTamanio).HasColumnName("KeyTamanio");
            Property(e => e.KeyTamanio).HasMaxLength(5);


            // Relaciones a uno
            Property(e => e.AsmAgenteId).IsRequired();
            Property(e => e.AsmAgenteId).HasColumnName("IdAgente");
            HasRequired(e => e.AsmAgente).WithMany(i => i.Mascotas).HasForeignKey(i => i.AsmAgenteId);


        }
    }
}
