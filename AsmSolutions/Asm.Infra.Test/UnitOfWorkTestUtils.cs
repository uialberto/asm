using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Dominio.Apolo.Entities;
using Asm.Dominio.Apolo.Repositories;

namespace Asm.Infra.Test
{
    public static class UnitOfWorkTestUtils
    {
        private static UnitOfWork _unitOfWork = null;
        public static UnitOfWork GetUnitOfWork()
        {
            if (_unitOfWork != null) return _unitOfWork;
            _unitOfWork = new UnitOfWork();
            _unitOfWork.Configuration.ValidateOnSaveEnabled = false;
            return _unitOfWork;
        }
        public static void RestartUnitOfWork()
        {
            _unitOfWork?.Dispose();
            _unitOfWork = new UnitOfWork();
        }

    }
}
