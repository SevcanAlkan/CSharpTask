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
    public class BaseController<S, B, L, E> : Controller
        where S : SaveVM, ISaveVM, new()
        where E : EditVM<S>, IEditVM<S>, new()
        where B : BaseVM, IBaseVM, new()
        where L : PaggingListVM<B>, IPaggingListVM<B>, new()
    {
        protected readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _name;
        private string _listPage { get; set; }

        protected HttpClient _httpClient { get
            {
                return _httpClientFactory.CreateClient();
            } 
        }

        public BaseController(IConfiguration config, IHttpClientFactory httpClientFactory, string name, string listPage = "Index")
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
            _name = name;
            _listPage = listPage;
        }

        public virtual async Task<IActionResult> Index(int pageNumber = 1, string message = "")
        {
            try
            {
                ViewData["PageNumber"] = pageNumber;
                ViewData["Message"] = message;

                L paggingListVM = new L();
                var client = _httpClient;

                var baseURL = _config["API:BaseURL"];
                client.BaseAddress = new Uri(baseURL);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMessage = await client.GetAsync($"{_name}?pageNumber={pageNumber}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseBody = responseMessage.Content.ReadAsStringAsync().Result;
                    paggingListVM = JsonConvert.DeserializeObject<L>(responseBody);
                }

                paggingListVM.Pagging.ActionName = _listPage;
                paggingListVM.Pagging.ControllerName = _name;

                return View(paggingListVM);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw;
            }
        }

        public virtual async Task<IActionResult> Edit(Guid? id = null)
        {
            try
            {
                E editVM = new E();

                if (id == null || id == Guid.Empty)
                    return View(editVM);

                var client = _httpClientFactory.CreateClient();

                var baseURL = _config["API:BaseURL"];
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync($"{_name}/{id.Value}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseBody = responseMessage.Content.ReadAsStringAsync().Result;
                    editVM = JsonConvert.DeserializeObject<E>(responseBody);
                }

                return View(editVM);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Edit(Guid id, E vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            APIResultVM result = new APIResultVM();
            HttpResponseMessage responseMessage;
            string message = "";

            var client = _httpClientFactory.CreateClient();
            try
            {
                var baseURL = _config["API:BaseURL"];
                client.BaseAddress = new Uri(baseURL);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string json = JsonConvert.SerializeObject(vm);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                if (id == Guid.Empty)
                    responseMessage = await client.PostAsync(_name, httpContent);
                else
                    responseMessage = await client.PutAsync($"{_name}/{id}", httpContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    message = $"{_name} is saved!";
                }
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw;
            }
            finally
            {
                client.Dispose();
            }

            return RedirectToAction(_listPage, _name, new { message });
        }

        public virtual async Task<ActionResult> Delete(Guid? id = null)
        {
            if (id == null || id == Guid.Empty)
                return RedirectToAction(_listPage, _name);

            var client = _httpClientFactory.CreateClient();
            string message = "";

            try
            {
                var baseURL = _config["API:BaseURL"];
                client.BaseAddress = new Uri(baseURL);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseMessage = await client.DeleteAsync($"{_name}/{id}");

                if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    message = $"{_name} is deleted!";
                }
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw;
            }
            finally
            {
                client.Dispose();
            }

            return RedirectToAction(_listPage, _name, new { message });
        }
    }
}
