using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Core.ViewModel
{
    public interface IAPIResultVM<IDType>
    {
        IDType RecId { get; set; }
        bool IsSuccessful { get; set; }
        IEnumerable<APIResultErrorCodeVM> Errors { get; set; }
    }

    public record APIResultVM<IDType> : IAPIResultVM<IDType>
    {
        public IDType RecId { get; set; }
        public bool IsSuccessful { get; set; }

        public IEnumerable<APIResultErrorCodeVM> Errors { get; set; }
    }

    public interface IAPIResultVM : IAPIResultVM<Guid?>
    {
    }

    public record APIResultVM : APIResultVM<Guid?>, IAPIResultVM
    {
    }
}
