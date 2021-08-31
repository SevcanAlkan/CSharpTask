using Assingnement.Core.ViewModel;
using Assingnement.Core.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Core.Helper
{
    public abstract class APIResultBase<IDType>
    {
        public abstract APIResultVM<IDType> CreateVM(
            IDType recId,
            bool isSuccessful = false,
            IEnumerable<APIResultErrorCodeVM> errors = null);

        public abstract APIResultWithRecVM<IDType, T> CreateVMWithRec<T>(
            T rec,
            IDType recId,
            bool isSuccessful = false,
            IEnumerable<APIResultErrorCodeVM> errors = null);

        public abstract APIResultVM<IDType> CreateVMWithStatusCode(
            IDType recId,
            bool isSuccessful = false,
            string statusCode = "");

        public abstract APIResultVM<IDType> CreateVMWithModelState(
            IDType recId,
            bool isSuccessful = false,
            ModelStateDictionary modelStateDictionary = null);
    }

    public class APIResult : APIResultBase<Guid?>
    {
        public override APIResultVM CreateVM(
            Guid? recId = null,
            bool isSuccessful = false,
            IEnumerable<APIResultErrorCodeVM> errors = null)
        {
            var vm = new APIResultVM()
            {
                IsSuccessful = isSuccessful,
                RecId = recId,
                Errors = errors
            };
            return vm;
        }

        public override APIResultWithRecVM<T> CreateVMWithRec<T>(
            T rec,
            Guid? recId = null,
            bool isSuccessful = false,
            IEnumerable<APIResultErrorCodeVM> errors = null)
        {
            var vm = new APIResultWithRecVM<T>()
            {
                IsSuccessful = isSuccessful,
                RecId = recId,
                Rec = rec,
                Errors = errors
            };

            return vm;
        }
        public override APIResultVM CreateVMWithStatusCode(
            Guid? recId = null,
            bool isSuccessful = false,
            string statusCode = "")
        {
            var errors = new List<APIResultErrorCodeVM>();
            errors.Add(new APIResultErrorCodeVM()
            {
                Field = "General",
                ErrorCode = statusCode
            });

            return CreateVM(recId, isSuccessful, errors.AsEnumerable<APIResultErrorCodeVM>());
        }

        public override APIResultVM CreateVMWithModelState(
            Guid? recId = null,
            bool isSuccessful = false,
            ModelStateDictionary modelStateDictionary = null)
        {
            return CreateVM(
                recId,
                isSuccessful,
                modelStateDictionary.GetErrors());
        }
    }

    public class APIResult<IDType> : APIResultBase<IDType>
    {
        public override APIResultVM<IDType> CreateVM(
            IDType recId,
            bool isSuccessful = false,
            IEnumerable<APIResultErrorCodeVM> errors = null)
        {
            var vm = new APIResultVM<IDType>()
            {
                IsSuccessful = isSuccessful,
                RecId = recId,
                Errors = errors
            };
            return vm;
        }

        public override APIResultWithRecVM<IDType, T> CreateVMWithRec<T>(
            T rec,
            IDType recId,
            bool isSuccessful = false,
            IEnumerable<APIResultErrorCodeVM> errors = null)
        {
            var vm = new APIResultWithRecVM<IDType, T>()
            {
                IsSuccessful = isSuccessful,
                RecId = recId,
                Rec = rec,
                Errors = errors
            };

            return vm;
        }
        public override APIResultVM<IDType> CreateVMWithStatusCode(
            IDType recId,
            bool isSuccessful = false,
            string statusCode = "")
        {
            var errors = new List<APIResultErrorCodeVM>();
            errors.Add(new APIResultErrorCodeVM()
            {
                Field = "General",
                ErrorCode = statusCode
            });

            return CreateVM(recId, isSuccessful, errors.AsEnumerable<APIResultErrorCodeVM>());
        }

        public override APIResultVM<IDType> CreateVMWithModelState(
            IDType recId,
            bool isSuccessful = false,
            ModelStateDictionary modelStateDictionary = null)
        {
            return CreateVM(
                recId,
                isSuccessful,
                modelStateDictionary.GetErrors());
        }
    }
}
