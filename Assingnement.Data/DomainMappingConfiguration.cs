using Assingnement.Data.ViewModel;
using Assingnement.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Data
{
    public class DomainMappingConfiguration : Profile
    {
        public DomainMappingConfiguration()
        {
            CreateMap<Brand, BrandVM>();
            CreateMap<Brand, BrandSaveVM>().ReverseMap();
            CreateMap<Brand, BrandEditVM>().ReverseMap();

            CreateMap<Car, CarVM>().ReverseMap();
            CreateMap<Car, CarSaveVM>().ReverseMap();
            CreateMap<Car, CarEditVM>().ReverseMap();

            CreateMap<Owner, OwnerVM>();
            CreateMap<Owner, OwnerSaveVM>().ReverseMap();
            CreateMap<Owner, OwnerEditVM>().ReverseMap();

            CreateMap<Model, ModelVM>();
            CreateMap<Model, ModelSaveVM>().ReverseMap();
            CreateMap<Model, ModelEditVM>().ReverseMap();
        }
    }
}
