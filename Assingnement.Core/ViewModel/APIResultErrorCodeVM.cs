using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Core.ViewModel
{
    public record APIResultErrorCodeVM
    {
        public string Field { get; set; }
        public string ErrorCode { get; set; }
    }
}
