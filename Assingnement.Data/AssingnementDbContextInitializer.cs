using Assingnement.Core.Enum;
using Assingnement.Data.SubStructure;
using Assingnement.Domain;
using Microsoft.EntityFrameworkCore;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Data
{
    public class DeliveryKingDbContextInitializer
    {
        public static void Seed(ref ModelBuilder builder)
        {
            try
            {
                #region Brand

                Brand Audi = new Brand() { Id = new Guid("1387D29D-C0DA-4249-88C6-DB358C81CD90"), Name = "Audi" };
                Brand Mercedes = new Brand() { Id = new Guid("456F0A0D-B207-4DE6-8670-5C253F460768"), Name = "Mercedes" };
                Brand BMW = new Brand() { Id = new Guid("54E7F57B-161D-412E-B420-614FEA1ACA6E"), Name = "BMW" };
                Brand Volvo = new Brand() { Id = new Guid("BBDD8B15-D1DC-44CD-AD0D-B738E4B28592"), Name = "Volvo" };
                Brand Jaguar = new Brand() { Id = new Guid("04EEC85C-A70E-426B-B41D-CD74B364F321"), Name = "Jaguar" };

                builder.Entity<Brand>().HasData(Audi, Mercedes, BMW, Volvo, Jaguar);

                #endregion

                #region Model

                Model A6 = new Model()
                {
                    Id = new Guid("5A3A47AD-02EE-4929-BC80-3B2D48E72F57"),
                    Name = "A6",
                    BrandId = Audi.Id,
                    Year = 2007,
                    EngineCapacity = 2.0,
                    HoursePower = 320
                };
                Model V60 = new Model()
                {
                    Id = new Guid("C102AF54-D939-4CCA-8DE0-CBF6358FAF76"),
                    Name = "V60",
                    BrandId = Volvo.Id,
                    Year = 2019,
                    EngineCapacity = 2.0,
                    HoursePower = 190
                };
                Model XF = new Model()
                {
                    Id = new Guid("9633ADE9-E481-457F-BEC0-F6CA29E551E9"),
                    Name = "XF",
                    BrandId = Jaguar.Id,
                    Year = 2020,
                    EngineCapacity = 3.0,
                    HoursePower = 400
                };
                Model BMW540i = new Model()
                {
                    Id = new Guid("9F12071A-865F-4FD3-A501-022A6F9575C7"),
                    Name = "540i",
                    BrandId = BMW.Id,
                    Year = 2011,
                    EngineCapacity = 2.5,
                    HoursePower = 360
                };
                Model E63sAMG = new Model()
                {
                    Id = new Guid("61821C1D-0F7B-48D1-BC07-031E14512668"),
                    Name = "E63s AMG",
                    BrandId = Mercedes.Id,
                    Year = 2021,
                    EngineCapacity = 6.5,
                    HoursePower = 600
                };

                builder.Entity<Model>().HasData(A6, V60, XF, BMW540i, E63sAMG);

                #endregion

                #region Owner

                Owner Sevcan = new Owner() { Id = new Guid("BC4C27A3-B382-4E76-929B-0EA7C8118D3F"), FirstName = "Sevcan", LastName = "Alkan", BirthDate = new DateTime(1990, 8, 6) };
                Owner Ali = new Owner() { Id = new Guid("8DA05D93-1AE3-4BC4-B3B4-7A6EF582F168"), FirstName = "Ali", LastName = "Bulut", BirthDate = new DateTime(1985, 8, 6) };

                builder.Entity<Owner>().HasData(Sevcan, Ali);

                #endregion

                #region Car

                builder.Entity<Car>().HasData(
                   new Car()
                   {
                       Id = new Guid("BC4C27A3-B382-4E76-929B-0EA7C8118D3F"),
                       OwnerId = Sevcan.Id,
                       ModelId = A6.Id,
                       BoughtYear = 2011,
                       RegistrationNumber = "CA 7321 BH",
                       Color = BodyColor.Black
                   },
                   new Car()
                   {
                       Id = new Guid("4B37220A-3AB4-4710-B76B-194376726FD7"),
                       OwnerId = Ali.Id,
                       ModelId = E63sAMG.Id,
                       BoughtYear = 2017,
                       RegistrationNumber = "A 8256 KX",
                       Color = BodyColor.Green
                   });

                #endregion
            }
            catch (System.Exception e)
            {
                SentrySdk.CaptureException(e);
            }
        }
    }
}
