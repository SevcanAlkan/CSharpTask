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
    public class BrandService : BaseService<BrandSaveVM, BrandEditVM, BrandVM, BrandPaggingListVM, Brand>, IBrandService
    {
        #region Ctor

        private IModelService _modelService;

        public BrandService(UnitOfWork uow,
            IMapper mapper,
            IModelService modelService,
            APIResult apiResult)
            : base(uow, mapper, apiResult)
        {
            _modelService = modelService;
        }

        #endregion

        #region Methods

        public override Task<IAPIResultVM> DeleteAsync(Guid id, bool isCommit = true)
        {
            var models = _modelService.Query().Where(a => a.BrandId == id && !a.IsDeleted).ToList();

            foreach (var item in models)
            {
                _modelService.DeleteAsync(item.Id, isCommit);
            }

            return base.DeleteAsync(id, isCommit);
        }

        #endregion
    }

    public interface IBrandService : IBaseService<BrandSaveVM, BrandEditVM, BrandVM, BrandPaggingListVM, Brand>
    {
    }
}
