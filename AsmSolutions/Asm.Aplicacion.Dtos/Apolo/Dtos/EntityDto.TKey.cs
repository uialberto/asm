using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm.Aplicacion.Dtos.Apolo.Dtos
{
    public abstract class EntityDto<TPrimaryKey>
    {
        protected EntityDto()
        {
        }

        protected EntityDto(TPrimaryKey value)
        {
            Id = value;
        }
        public virtual TPrimaryKey Id { get; set; }
    }
}
