using Assingnement.Core;
using Assingnement.Core.EntityFramework;
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
    public interface IRepository<T>
    {
        Task<T> GetByIDAsync(Guid id);
        IQueryable<T> Get();
        IQueryable<T> Query(bool isDeleted = false);
        void Add(T entity);
        void Update(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expr);
    }

    public class Repository<T> : IRepository<T>
        where T : BaseEntity, IBaseEntity, new()
    {
        private AssingnementDbContext con;
        public Repository(AssingnementDbContext context)
        {
            con = context;
        }
        public AssingnementDbContext Context
        {
            get { return con; }
            set { con = value; }

        }
        public virtual async Task<T> GetByIDAsync(Guid id)
        {
            try
            {
                return await con.Set<T>().FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return default(T);
            }
        }
        public IQueryable<T> Get()
        {
            try
            {
                return con.Set<T>().AsQueryable();
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return null;
            }
        }
        public virtual void Add(T entity)
        {
            try
            {
                con.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }
        public virtual void Update(T entity)
        {
            try
            {
                con.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }
        public IQueryable<T> Query(bool showIsDeleted = false)
        {
            try
            {
                return con.Set<T>().Where(x => !x.IsDeleted || showIsDeleted).AsQueryable();
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return null;
            }
        }
        public Task<bool> AnyAsync(Expression<Func<T, bool>> expr)
        {
            try
            {
                return con.Set<T>().AsNoTracking().AnyAsync(expr);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return null;
            }
        }
    }
}