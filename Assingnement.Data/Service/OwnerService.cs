using Assingnement.Core.Helper;
using Assingnement.Core.ViewModel;
using Assingnement.Data.SubStructure;
using Assingnement.Data.ViewModel;
using Assingnement.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Data.Service
{
    public class OwnerService : BaseService<OwnerSaveVM, OwnerEditVM, OwnerVM, OwnerPaggingListVM, Owner>, IOwnerService
    {
        #region Ctor

        private ICarService _carService;

        public OwnerService(UnitOfWork uow,
            IMapper mapper,
            APIResult apiResult,
            ICarService carService)
            : base(uow, mapper, apiResult)
        {
            _carService = carService;
        }

        #endregion

        #region Methods

        public override Task<IAPIResultVM> DeleteAsync(Guid id, bool isCommit = true)
        {
            var cars = _carService.Query().Where(a => a.OwnerId == id && !a.IsDeleted).ToList();

            foreach (var item in cars)
            {
                _carService.DeleteAsync(item.Id, isCommit);
            }

            return base.DeleteAsync(id, isCommit);
        }

        #endregion
    }

    public interface IOwnerService : IBaseService<OwnerSaveVM, OwnerEditVM, OwnerVM, OwnerPaggingListVM, Owner>
    {
    }
}
