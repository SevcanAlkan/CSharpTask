using Assingnement.Core.ViewModel;
using Assingnement.Data.Service;
using Assingnement.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ModelController : BaseController<ModelSaveVM, ModelVM, ModelPaggingListVM, ModelEditVM>
    {
        public ModelController(IConfiguration config, IHttpClientFactory httpClientFactory)
            : base(config, httpClientFactory, "Model")
        {
        }

        public override async Task<IActionResult> Edit(Guid? id = null)
        {
            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem > brands = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            var client = _httpClient;

            var baseURL = _config["API:BaseURL"];
            client.BaseAddress = new Uri(baseURL);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage responseMessage = await client.GetAsync($"brand/GetSelectList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseBody = responseMessage.Content.ReadAsStringAsync().Result;
                brands = JsonConvert.DeserializeObject<List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>>(responseBody);
            }

            ViewData["BrandList"] = brands;

            return await base.Edit(id);
        }

        public override Task<ActionResult> Edit(Guid id, ModelEditVM vm)
        {
            Guid.TryParse(vm.BrandIdStr, out Guid brandId);

            vm.Rec.BrandId = brandId;

            return base.Edit(id, vm);
        }
    }
}
