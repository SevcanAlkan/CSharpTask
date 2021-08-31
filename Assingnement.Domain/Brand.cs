using Assingnement.Core;
using Assingnement.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Domain
{
    public record BrandBase : BaseEntity
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }
    }

    public record Brand : BrandBase
    {
        public virtual ICollection<Model> Models { get; set; }

        public Brand()
        {
            Models = new HashSet<Model>();
        }
    }
}
