using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Core.ViewModel
{
    public interface IEditVM<T>
        where T : SaveVM, ISaveVM, new()
    {
        Guid Id { get; set; }
        public T Rec { get; set; }
        public string GeneralError { get; set; }
    }
    public class EditVM<T> : IEditVM<T>
        where T : SaveVM, ISaveVM, new()
    {
        public Guid Id { get; set; }
        public T Rec { get; set; }
        public string GeneralError { get; set; }
    }
}
