using Assingnement.Core;
using Assingnement.Core.Helper;
using Assingnement.Core.Validation;
using Assingnement.Data.Service;
using Assingnement.Data.ViewModel;
using Assingnement.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assingnement.API.Controllers
{
    public class CarController : DefaultApiCRUDController<CarSaveVM, CarEditVM, CarVM, CarPaggingListVM, Car, ICarService>
    {
        public CarController(ICarService service, APIResult apiResult)
            : base(service, apiResult, o => o.RegistrationNumber)
        {

        }

        [Route("GetAllWhitFilters")]
        public JsonResult GetAllWhitFilters(
            Guid? brandId = null,
            Guid? modelId = null,
            Guid? ownerId = null, 
            int pageNumber = 1, 
            int itemPerPage = 10)
        {
            var result = _service.GetAllWithFilters(brandId, modelId, ownerId, pageNumber, itemPerPage);
            if (result == null)
                return new JsonAPIResult(_apiResult.CreateVMWithStatusCode(null, false, APIStatusCode.ERR01003),
                    StatusCodes.Status204NoContent);

            return new JsonAPIResult(result, StatusCodes.Status200OK);
        }
    }
}
