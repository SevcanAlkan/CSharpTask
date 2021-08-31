using Assingnement.Core;
using Assingnement.Core.EntityFramework;
using Assingnement.Core.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Domain
{
    public record ModelBase : BaseEntity
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        [Required]
        [Range(0.1, 15)]
        public double EngineCapacity { get; set; }

        [Required]
        [Range(20, 5000)]
        public int HoursePower { get; set; }

        [GuidValidation]
        public Guid BrandId { get; set; }
    }

    public record Model : ModelBase
    {
        public virtual Brand Brand { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public Model()
        {
            Cars = new HashSet<Car>();
        }
    }
}
