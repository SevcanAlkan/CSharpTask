using Assingnement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Data.ViewModel
{
    public class OwnerVM : BaseVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class OwnerPaggingListVM : PaggingListVM<OwnerVM>
    {
    }

    public class OwnerEditVM : EditVM<OwnerSaveVM>
    {
    }

    public class OwnerSaveVM : SaveVM
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        [StringLength(maximumLength: 50, MinimumLength = 3,
            ErrorMessage = "First name cannot be longer than 50 characters and less than 3 characters")]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        [StringLength(maximumLength: 50, MinimumLength = 3,
            ErrorMessage = "Last name cannot be longer than 50 characters and less than 3 characters")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Birth date")]
        public DateTime BirthDate { get; set; }
    }
}
