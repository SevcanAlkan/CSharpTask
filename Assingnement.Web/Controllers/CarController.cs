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

    public class CarController : BaseController<CarSaveVM, CarVM, CarPaggingListVM, CarEditVM>
    {
        public CarController(IConfiguration config, IHttpClientFactory httpClientFactory)
            : base(config, httpClientFactory, "Car", "List")
        {
        }

        public async Task<IActionResult> List(
            Guid? brandId = null,
            Guid? modelId = null,
            Guid? ownerId = null, 
            int pageNumber = 1, 
            string message = "")
        {
            try
            {
                ViewData["PageNumber"] = pageNumber;
                ViewData["Message"] = message;
                ViewData["BrandId"] = brandId;
                ViewData["ModelId"] = modelId;
                ViewData["OwnerId"] = ownerId;

                string path = $"Car/GetAllWhitFilters?brandId={brandId}&modelId={modelId}&ownerId={ownerId}&pageNumber={pageNumber}";

                CarPaggingListVM paggingListVM = new CarPaggingListVM();
                var client = _httpClient;

                var baseURL = _config["API:BaseURL"];
                client.BaseAddress = new Uri(baseURL);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMessage = await client.GetAsync(path);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseBody = responseMessage.Content.ReadAsStringAsync().Result;
                    paggingListVM = JsonConvert.DeserializeObject<CarPaggingListVM>(responseBody);
                }

                paggingListVM.Pagging.ActionName = "List";
                paggingListVM.Pagging.ControllerName = "Car";

                paggingListVM.ToolbarData = new CarToolbarVM();

                paggingListVM.ToolbarData.Brands = await GetGuidDropdownData("Brand");
                paggingListVM.ToolbarData.Owners = await GetGuidDropdownData("Owner");
                paggingListVM.ToolbarData.Models = await GetGuidDropdownData("Model");

                return View(paggingListVM);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw;
            }
        }

        public override async Task<IActionResult> Edit(Guid? id = null)
        {
            ViewData["ModelList"] = await GetDropdownData("Model"); ;
            ViewData["OwnerList"] = await GetDropdownData("Owner"); ;

            return await base.Edit(id);
        }

        public override Task<ActionResult> Edit(Guid id, CarEditVM vm)
        {
            Guid.TryParse(vm.ModelIdStr, out Guid modelId);
            vm.Rec.ModelId = modelId;

            Guid.TryParse(vm.OwnerIdStr, out Guid ownerId);
            vm.Rec.OwnerId = ownerId;

            return base.Edit(id, vm);
        }

        private async Task<List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>> GetDropdownData(string resourceName)
        {
            try
            {
                var client = _httpClient;
                List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> result = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

                var baseURL = _config["API:BaseURL"];
                client.BaseAddress = new Uri(baseURL);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMessage = await client.GetAsync(resourceName + "/GetSelectList");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseBody = responseMessage.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>>(responseBody);
                }

                return result;
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw;
            }
        }

        private async Task<List<SelectListItem>> GetGuidDropdownData(string resourceName)
        {
            try
            {
                var client = _httpClient;
                List<SelectListItem> result = new List<SelectListItem>();

                var baseURL = _config["API:BaseURL"];
                client.BaseAddress = new Uri(baseURL);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMessage = await client.GetAsync(resourceName + "/GetSelectListGuid");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseBody = responseMessage.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<SelectListItem>>(responseBody);
                }

                return result;
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw;
            }
        }
    }
}
