using Asm.Apolo.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asm.WebApi.Helpers
{
    
    public class ResultData<T> : ResultOperation
    {
        public ResultData()
        {

        }

        public T Data { get; set; }

        public void AddError(string error)
        {
            this.Errors.Add(error);
        }
    }
    public class ResultData : ResultOperation
    {
        public ResultData()
        {

        }
        public object Data { get; set; }

        public void AddError(string error)
        {
            this.Errors.Add(error);
        }
    }
}