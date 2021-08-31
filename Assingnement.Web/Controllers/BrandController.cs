using Assingnement.Core.ViewModel;
using Assingnement.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Assingnement.Web.Controllers
{
    public class BrandController : BaseController<BrandSaveVM, BrandVM, BrandPaggingListVM, BrandEditVM>
    {
        public BrandController(IConfiguration config, IHttpClientFactory httpClientFactory)
            : base(config, httpClientFactory, "Brand")
        {
        }
    }
}
