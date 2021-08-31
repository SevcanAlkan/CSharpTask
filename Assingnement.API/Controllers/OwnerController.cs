using Assingnement.Core.Helper;
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
    public class OwnerController : DefaultApiCRUDController<OwnerSaveVM, OwnerEditVM, OwnerVM, OwnerPaggingListVM, Owner, IOwnerService>
    {
        public OwnerController(IOwnerService service, APIResult apiResult)
            : base(service, apiResult, o => o.FirstName)
        {

        }

        [HttpGet]
        [Route("GetSelectList")]
        public IActionResult GetSelectList()
        {
            var result = _service.Query().Where(a => !a.IsDeleted).Select(s => new SelectListItem()
            {
                Text = s.FirstName + " " + s.LastName,
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
                DisplayText = s.FirstName + " " + s.LastName,
                Id = s.Id
            }).OrderBy(o => o.DisplayText).ToList();

            if (result == null)
                return NoContent();

            return Ok(result);
        }
    }
}
