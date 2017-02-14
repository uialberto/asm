using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Dominio.Modulos.Core.Agregados.AsmAgentes;

namespace Asm.Infra.Modulos.Core.Mapping.AsmAgentes
{
    public partial class AsmAgenteConfig : EntityTypeConfiguration<AsmAgente>
    {
        public AsmAgenteConfig()
        {
            Configure();
        }

        public virtual void Configure()
        {
            HasKey(e => e.Id);
            ToTable("core.AsmAgentes");

            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Propiedades escalares
            Property(e => e.Id).HasColumnName("IdAgente");

            Property(e => e.Nombres).IsRequired();
            Property(e => e.Nombres).HasColumnName("Nombres");
            Property(e => e.Nombres).HasMaxLength(300);

            Property(e => e.Apellidos).IsOptional();
            Property(e => e.Apellidos).HasColumnName("Apellidos");
            Property(e => e.Apellidos).HasMaxLength(300);


            Property(e => e.Celular).IsOptional();
            Property(e => e.Celular).HasColumnName("Celular");
            Property(e => e.Celular).HasMaxLength(20);


            Property(e => e.Telefono).IsOptional();
            Property(e => e.Telefono).HasColumnName("Telefono");
            Property(e => e.Telefono).HasMaxLength(20);

            Property(e => e.Direccion).IsOptional();
            Property(e => e.Direccion).HasColumnName("Direccion");
            Property(e => e.Direccion).HasMaxLength(500);

            // Relaciones a uno
            Property(e => e.UserId).IsRequired();
            Property(e => e.UserId).HasColumnName("IdUser");
            HasRequired(e => e.User).WithMany(i => i.AsmAgentes).HasForeignKey(i => i.UserId);

            // Relaciones a muchos
            HasMany(e => e.Mascotas)
                .WithRequired(i => i.AsmAgente)
                .HasForeignKey(i => i.AsmAgenteId);

        }
    }
}
