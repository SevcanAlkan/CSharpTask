using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Core.EntityFramework
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        bool IsDeleted { get; set; }
    }
    public record BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
