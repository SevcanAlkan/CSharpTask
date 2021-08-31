using Assingnement.Core;
using Assingnement.Core.Helper;
using Assingnement.Core.Validation;
using Assingnement.Data.Service;
using Assingnement.Data.ViewModel;
using Assingnement.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assingnement.API.Controllers
{
    public class BrandController : DefaultApiCRUDController<BrandSaveVM, BrandEditVM, BrandVM, BrandPaggingListVM, Brand, IBrandService>
    {
        public BrandController(IBrandService service, APIResult apiResult) 
            : base(service, apiResult, o => o.Name)
        {

        }

        [HttpGet]
        [Route("GetSelectList")]
        public IActionResult GetSelectList()
        {
            var result = _service.Query().Where(a => !a.IsDeleted).Select(s => new SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).OrderBy(o => o.Text).ToList();

            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetSelectListGuid")]
        public IActionResult GetSelectListGuid()
        {
            var result = _service.Query().Where(a => !a.IsDeleted).Select(s => new Assingnement.Core.ViewModel.SelectListItem()
            {
                DisplayText = s.Name,
                Id = s.Id
            }).OrderBy(o => o.DisplayText).ToList();

            if (result == null)
                return NoContent();

            return Ok(result);
        }
    }
}
