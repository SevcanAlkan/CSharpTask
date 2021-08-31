using Assingnement.Core.Enum;
using Assingnement.Core.Validation;
using Assingnement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Data.ViewModel
{
    public class CarVM : BaseVM
    {
        public BodyColor Color { get; set; }
        public string RegistrationNumber { get; set; }
        public int BoughtYear { get; set; }
        public Guid OwnerId { get; set; }
        public Guid ModelId { get; set; }

        public string OwnerName { get; set; }
        public string ModelName { get; set; }
    }

    public class CarPaggingListVM : PaggingListVM<CarVM>
    {
        public CarToolbarVM ToolbarData { get; set; }
    }

    public class CarEditVM : EditVM<CarSaveVM>
    {
        [Required(ErrorMessage = "Model is required")]
        [Display(Name = "Model")]
        public string ModelIdStr { get; set; }
        [Required(ErrorMessage = "Owner is required")]
        [Display(Name = "Owner")]
        public string OwnerIdStr { get; set; }
    }

    public class CarSaveVM : SaveVM
    {
        [Required(ErrorMessage = "Body color is required")]
        [Display(Name = "Body Color")]
        public BodyColor Color { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Registration number is required")]
        [Display(Name = "Registration Number")]
        [StringLength(maximumLength: 15, MinimumLength = 5, ErrorMessage = "Registration number cannot be longer than 15 characters and less than 5 characters")]
        public string RegistrationNumber { get; set; }

        [Required(ErrorMessage = "Bought year is required")]
        [Display(Name = "Bought Year")]
        [Range(1900, 2100)]
        public int BoughtYear { get; set; }

        public Guid OwnerId { get; set; }
        public Guid ModelId { get; set; }
    }

    public class CarToolbarVM
    {
        [DefaultValue(CarSortOption.ReqitrationNUmber)]
        public CarSortOption Sort { get; set; }

        public List<SelectListItem> Brands { get; set; }
        public List<SelectListItem> Models { get; set; }
        public List<SelectListItem> Owners { get; set; }
    }
}
