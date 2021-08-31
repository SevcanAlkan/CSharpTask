using Assingnement.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Domain
{

    public record OwnerBase : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }

    public record Owner : OwnerBase
    {
        public virtual ICollection<Car> Cars { get; set; }

        public Owner()
        {
            Cars = new HashSet<Car>();
        }
    }
}
