using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assingnement.API.Controllers
{
    /// <summary>
    /// Default controller, it contains basic functionality of the API Controller
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    public abstract class DefaultApiController : ControllerBase
    {
        #region Properties and Fields



        #endregion

        #region Ctor

#pragma warning disable 1591

        public DefaultApiController()
        {
        }
#pragma warning restore 1591

        #endregion
    }
}
