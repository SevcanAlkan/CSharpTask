using Assingnement.Core.EntityFramework;
using Assingnement.Core.Helper;
using Assingnement.Core.Validation;
using Assingnement.Core.ViewModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Data.SubStructure
{
    public interface IBaseService<S, E, B, L, D>
        where S : SaveVM, ISaveVM, new()
        where E : EditVM<S>, IEditVM<S>, new()
        where B : BaseVM, IBaseVM, new()
        where L : PaggingListVM<B>, IPaggingListVM<B>, new()
        where D : BaseEntity, IBaseEntity, new()
    {
        IQueryable<D> Query(bool showIsDeleted = false);
        Task<bool> AnyAsync(Guid id);
        Task<bool> AnyAsync(Expression<Func<D, bool>> expr);
        Task<E> GetByIdAsync(Guid id);
        Task<L> GetAllAsync(Expression<Func<D, dynamic>> orderBy,
            Expression<Func<D, bool>> expr = null,
            int pageNumber = 1,
            int itemPerPage = 10,
            bool asNoTracking = true);
        Task<IAPIResultVM> AddAsync(S model, bool isCommit = true);
        Task<IAPIResultVM> UpdateAsync(Guid id, S model, bool isCommit = true);
        Task<IAPIResultVM> DeleteAsync(Guid id, bool isCommit = true);
        Task<IAPIResultVM> CommitAsync();
    }

    public class BaseService<S, E, B, L, D> : IBaseService<S, E, B, L, D>
        where S : SaveVM, ISaveVM, new()
        where E : EditVM<S>, IEditVM<S>, new()
        where B : BaseVM, IBaseVM, new()
        where L : PaggingListVM<B>, IPaggingListVM<B>, new()
        where D : BaseEntity, IBaseEntity, new()
    {
        protected UnitOfWork _uow;
        protected readonly IMapper _mapper;
        protected readonly APIResult _apiResult;

        public BaseService(UnitOfWork uow, IMapper mapper, APIResult apiResult)
        {
            _uow = uow;
            _mapper = mapper;
            _apiResult = apiResult;
        }

        protected IRepository<D> Repository
        {
            get
            {
                return _uow.Repository<D>();
            }
        }

        public IQueryable<D> Query(bool showIsDeleted = false)
        {
            try
            {
                return Repository.Query(showIsDeleted);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return null;
            }
        }
        public virtual async Task<bool> AnyAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return false;

                return await _uow.Repository<D>().AnyAsync(a => a.Id == id);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return false;
            }
        }
        public virtual async Task<bool> AnyAsync(Expression<Func<D, bool>> expr)
        {
            try
            {
                if (expr == null)
                    return false;

                return await _uow.Repository<D>().AnyAsync(expr);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return false;
            }
        }

        public virtual async Task<E> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return null;

                E result = new E();

                result.Rec = _mapper.Map<S>(await _uow.Repository<D>().GetByIDAsync(id));
                result.Id = id;

                return result;
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return null;
            }
        }
        public virtual async Task<L> GetAllAsync(Expression<Func<D, dynamic>> orderBy, 
            Expression<Func<D, bool>> expr = null, 
            int pageNumber = 1, 
            int itemPerPage = 10, 
            bool asNoTracking = true)
        {
            try
            {
                L result = new L();

                var query = Repository.Query().OrderBy(orderBy).AsQueryable();

                if (expr != null)
                    query = query.Where(expr);

                if (asNoTracking)
                    query = query.AsNoTracking();

                if (pageNumber > 1)
                    query = query.Skip((pageNumber - 1) * itemPerPage);

                result.Records = await _mapper.ProjectTo<B>(query).ToListAsync();

                #region Next Page Check
                query = Repository.Query().AsNoTracking().AsQueryable();

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
       
        public virtual async Task<IAPIResultVM> AddAsync(S model, bool isCommit = true)
        {
            try
            {
                D entity = _mapper.Map<S, D>(model);
                if (entity.Id == Guid.Empty)
                    entity.Id = Guid.NewGuid();

                Repository.Add(entity);

                if (isCommit)
                    await CommitAsync();

                return _apiResult.CreateVMWithRec(entity, entity.Id, true);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return _apiResult.CreateVM();
            }
        }
        public virtual async Task<IAPIResultVM> UpdateAsync(Guid id, S model, bool isCommit = true)
        {
            try
            {
                D entity = await _uow.Repository<D>().GetByIDAsync(id);
                if (entity == null || entity == default(D))
                    return _apiResult.CreateVMWithStatusCode(id, false, APIStatusCode.ERR01003);

                entity = _mapper.Map<S, D>(model, entity);

                Repository.Update(entity);

                if (isCommit)
                    await CommitAsync();

                return _apiResult.CreateVMWithRec(entity, entity.Id, true);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return _apiResult.CreateVM();
            }
        }
        public virtual async Task<IAPIResultVM> DeleteAsync(Guid id, bool isCommit = true)
        {
            try
            {
                D entity = await _uow.Repository<D>().GetByIDAsync(id);
                if (entity == null || entity == default(D))
                    return _apiResult.CreateVMWithStatusCode(id, false, APIStatusCode.ERR01002);

                entity.IsDeleted = true;
                Repository.Update(entity);

                if (isCommit)
                    await CommitAsync();

                return _apiResult.CreateVMWithRec(entity, entity.Id, true);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return _apiResult.CreateVM();
            }
        }

        public virtual async Task<IAPIResultVM> CommitAsync()
        {
            try
            {
                await _uow.SaveChangesAsync();

                return _apiResult.CreateVM(isSuccessful: true);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return _apiResult.CreateVM();
            }
        }
    }
}
