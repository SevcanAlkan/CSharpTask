using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Core.ViewModel
{
    public class PaggingVM
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public bool IsNextPageExist { get; set; }
    }
}
