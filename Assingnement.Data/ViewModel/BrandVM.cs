using Assingnement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Data.ViewModel
{
    public class BrandVM : BaseVM
    {
        public string Name { get; set; }
    }

    public class BrandPaggingListVM : PaggingListVM<BrandVM>
    {
    }

    public class BrandEditVM : EditVM<BrandSaveVM>
    {
    }

    public class BrandSaveVM : SaveVM
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        [StringLength(maximumLength: 100, MinimumLength = 5,
            ErrorMessage = "Name cannot be longer than 100 characters and less than 5 characters")]
        public string Name { get; set; }
    }
}
