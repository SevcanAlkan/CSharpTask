using Assingnement.Core;
using Assingnement.Core.EntityFramework;
using Assingnement.Core.Enum;
using Assingnement.Core.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Assingnement.Domain
{
    public record CarBase : BaseEntity
    {
        [Required]
        public BodyColor Color { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string RegistrationNumber { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int BoughtYear { get; set; }

        [GuidValidation]
        public Guid OwnerId { get; set; }
        [GuidValidation]
        public Guid ModelId { get; set; }
    }

    public record Car : CarBase
    {
        public virtual Owner Owner { get; set; }
        public virtual Model Model { get; set; }

        public Car()
        {

        }
    }
}
