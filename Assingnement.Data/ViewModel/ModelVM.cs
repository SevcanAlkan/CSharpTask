using Assingnement.Core.Validation;
using Assingnement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Data.ViewModel
{
    public class ModelVM : BaseVM
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public double EngineCapacity { get; set; }
        public int HoursePower { get; set; }
        public Guid BrandId { get; set; }

        public string BrandName { get; set; }
    }

    public class ModelPaggingListVM : PaggingListVM<ModelVM>
    {
    }

    public class ModelEditVM : EditVM<ModelSaveVM>
    {
        [Required(ErrorMessage = "Brand is required")]
        [Display(Name = "Brand")]
        public string BrandIdStr { get; set; }
    }

    public class ModelSaveVM : SaveVM
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        [StringLength(maximumLength: 100, MinimumLength = 5,
           ErrorMessage = "Name cannot be longer than 100 characters and less than 5 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Display(Name = "Model Year")]
        [Range(1900, 2100)]
        public int Year { get; set; }

        [Required(ErrorMessage = "Engine capacity is required")]
        [Display(Name = "Engine Capacity (liter)")]
        [Range(0.1, 15)]
        public double EngineCapacity { get; set; }

        [Required(ErrorMessage = "Hourse power is required")]
        [Display(Name = "Hourse Power")]
        [Range(20, 5000)]
        public int HoursePower { get; set; }

        public Guid BrandId { get; set; }
    }
}
