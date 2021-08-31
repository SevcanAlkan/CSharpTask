using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Core.ViewModel
{
    public interface IAPIResultWithRecVM<T> : IAPIResultWithRecVM<Guid?, T>, IAPIResultVM
    {
    }
    public record APIResultWithRecVM<T> : APIResultWithRecVM<Guid?, T>, IAPIResultWithRecVM<T>
    {
    }

    public interface IAPIResultWithRecVM<IDType, T> : IAPIResultVM<IDType>
    {
        T Rec { get; set; }
    }
    public record APIResultWithRecVM<IDType, T> : APIResultVM<IDType>, IAPIResultWithRecVM<IDType, T>
    {
        public T Rec { get; set; }
    }
}
