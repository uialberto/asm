using Asm.Aplicacion.Helpers;
using Asm.Aplicacion.Modulos.Core.Mascotas;
using Asm.WebApi.Helpers;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asm.WebApi.Models
{
    public class MascotaModel
    {
        private readonly IAppServiceMascotas _service;
        public MascotaModel()
        {
            var pModel = (IoCUnityConfiguration.UnityManager as UnityContainer).Resolve<IAppServiceMascotas>();
            if (pModel == null)
                throw new ArgumentNullException(nameof(pModel));
            _service = pModel;
        }
        public MascotaModel(IAppServiceMascotas pModel)
        {
            if (pModel == null)
                throw new ArgumentNullException(nameof(pModel));
            _service = pModel;
        }
        public ResultData CantidadMascotasOlvidadas()
        {
            var result = new ResultData();
            try
            {
                var res = _service.CantidadMascotasOlvidadas();
                if (res.HasErrors)
                {
                    result.Errors = res.Errors;
                    return result;
                }
                result.Data = new
                {
                    Total = res.Element,
                };
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }
            return result;
        }
    }
}