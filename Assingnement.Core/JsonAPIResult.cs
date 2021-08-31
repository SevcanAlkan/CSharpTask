using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Core
{
    public class JsonAPIResult : JsonResult
    {
        public JsonAPIResult(object value, int statusCode)
            : base(value)
        {
            StatusCode = statusCode;
        }
    }
}
