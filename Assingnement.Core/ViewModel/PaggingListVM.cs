using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Core.ViewModel
{
    public interface IPaggingListVM<T>
       where T : BaseVM, IBaseVM, new()
    {
        List<T> Records { get; set; }
        PaggingVM Pagging { get; set; }
    }
    public class PaggingListVM<T> : IPaggingListVM<T>
        where T : BaseVM, IBaseVM, new()
    {
        public List<T> Records { get; set; }
        public PaggingVM Pagging { get; set; }
    }
}
