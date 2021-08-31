using Assingnement.Core.Helper;
using Assingnement.Core.ViewModel;
using Assingnement.Data.SubStructure;
using Assingnement.Data.ViewModel;
using Assingnement.Domain;
using AutoMapper;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Data.Service
{
    public class CarService : BaseService<CarSaveVM, CarEditVM, CarVM, CarPaggingListVM, Car>, ICarService
    {
        #region Ctor

        public CarService(UnitOfWork uow,
            IMapper mapper,
            APIResult apiResult)
            : base(uow, mapper, apiResult)
        {
        }

        #endregion

        #region Methods

        public CarPaggingListVM GetAllWithFilters(
            Guid? brandId = null, 
            Guid? modelId = null,
            Guid? ownerId = null,
            int pageNumber = 1, 
            int itemPerPage = 10)
        {
            try
            {
                CarPaggingListVM result = new CarPaggingListVM();

                var query = Repository.Query().OrderBy(o => o.RegistrationNumber).AsQueryable();

                if (brandId != null && brandId != Guid.Empty)
                    query = query.Where(a => a.Model.BrandId == brandId.Value);

                if (modelId != null && modelId != Guid.Empty)
                    query = query.Where(a => a.ModelId == modelId.Value);

                if (ownerId != null && ownerId != Guid.Empty)
                    query = query.Where(a => a.OwnerId == ownerId.Value);

                if (pageNumber > 1)
                    query = query.Skip((pageNumber - 1) * itemPerPage);

                result.Records = query.Select(s => new CarVM()
                {
                    RegistrationNumber = s.RegistrationNumber,
                    BoughtYear = s.BoughtYear,
                    Id = s.Id,
                    OwnerId = s.OwnerId,
                    ModelId = s.ModelId,
                    Color = s.Color,
                    ModelName = s.Model.Name,
                    OwnerName = s.Owner.FirstName + " " + s.Owner.LastName
                }).ToList();

                #region Next Page Check
                result.Pagging = new PaggingVM();
                result.Pagging.IsNextPageExist = query.Skip((pageNumber * itemPerPage)).Take(1).Count() == 1;
                #endregion

                return result;
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return null;
            }
        }

        #endregion
    }

    public interface ICarService : IBaseService<CarSaveVM, CarEditVM, CarVM, CarPaggingListVM, Car>
    {
        CarPaggingListVM GetAllWithFilters(
            Guid? brandId = null,
            Guid? modelId = null,
            Guid? ownerId = null,
            int pageNumber = 1,
            int itemPerPage = 10);
    }
}
