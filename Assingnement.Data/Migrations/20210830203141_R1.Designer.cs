// <auto-generated />
using System;
using Assingnement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assingnement.Data.Migrations
{
    [DbContext(typeof(AssingnementDbContext))]
    [Migration("20210830203141_R1")]
    partial class R1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Assingnement.Domain.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1387d29d-c0da-4249-88c6-db358c81cd90"),
                            IsDeleted = false,
                            Name = "Audi"
                        },
                        new
                        {
                            Id = new Guid("456f0a0d-b207-4de6-8670-5c253f460768"),
                            IsDeleted = false,
                            Name = "Mercedes"
                        },
                        new
                        {
                            Id = new Guid("54e7f57b-161d-412e-b420-614fea1aca6e"),
                            IsDeleted = false,
                            Name = "BMW"
                        },
                        new
                        {
                            Id = new Guid("bbdd8b15-d1dc-44cd-ad0d-b738e4b28592"),
                            IsDeleted = false,
                            Name = "Volvo"
                        },
                        new
                        {
                            Id = new Guid("04eec85c-a70e-426b-b41d-cd74b364f321"),
                            IsDeleted = false,
                            Name = "Jaguar"
                        });
                });

            modelBuilder.Entity("Assingnement.Domain.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BoughtYear")
                        .HasColumnType("int");

                    b.Property<byte>("Color")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bc4c27a3-b382-4e76-929b-0ea7c8118d3f"),
                            BoughtYear = 2011,
                            Color = (byte)5,
                            IsDeleted = false,
                            ModelId = new Guid("5a3a47ad-02ee-4929-bc80-3b2d48e72f57"),
                            OwnerId = new Guid("bc4c27a3-b382-4e76-929b-0ea7c8118d3f"),
                            RegistrationNumber = "CA 7321 BH"
                        },
                        new
                        {
                            Id = new Guid("4b37220a-3ab4-4710-b76b-194376726fd7"),
                            BoughtYear = 2017,
                            Color = (byte)4,
                            IsDeleted = false,
                            ModelId = new Guid("61821c1d-0f7b-48d1-bc07-031e14512668"),
                            OwnerId = new Guid("8da05d93-1ae3-4bc4-b3b4-7a6ef582f168"),
                            RegistrationNumber = "A 8256 KX"
                        });
                });

            modelBuilder.Entity("Assingnement.Domain.Model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("EngineCapacity")
                        .HasColumnType("float");

                    b.Property<int>("HoursePower")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5a3a47ad-02ee-4929-bc80-3b2d48e72f57"),
                            BrandId = new Guid("1387d29d-c0da-4249-88c6-db358c81cd90"),
                            EngineCapacity = 2.0,
                            HoursePower = 320,
                            IsDeleted = false,
                            Name = "A6",
                            Year = 2007
                        },
                        new
                        {
                            Id = new Guid("c102af54-d939-4cca-8de0-cbf6358faf76"),
                            BrandId = new Guid("bbdd8b15-d1dc-44cd-ad0d-b738e4b28592"),
                            EngineCapacity = 2.0,
                            HoursePower = 190,
                            IsDeleted = false,
                            Name = "V60",
                            Year = 2019
                        },
                        new
                        {
                            Id = new Guid("9633ade9-e481-457f-bec0-f6ca29e551e9"),
                            BrandId = new Guid("04eec85c-a70e-426b-b41d-cd74b364f321"),
                            EngineCapacity = 3.0,
                            HoursePower = 400,
                            IsDeleted = false,
                            Name = "XF",
                            Year = 2020
                        },
                        new
                        {
                            Id = new Guid("9f12071a-865f-4fd3-a501-022a6f9575c7"),
                            BrandId = new Guid("54e7f57b-161d-412e-b420-614fea1aca6e"),
                            EngineCapacity = 2.5,
                            HoursePower = 360,
                            IsDeleted = false,
                            Name = "540i",
                            Year = 2011
                        },
                        new
                        {
                            Id = new Guid("61821c1d-0f7b-48d1-bc07-031e14512668"),
                            BrandId = new Guid("456f0a0d-b207-4de6-8670-5c253f460768"),
                            EngineCapacity = 6.5,
                            HoursePower = 600,
                            IsDeleted = false,
                            Name = "E63s AMG",
                            Year = 2021
                        });
                });

            modelBuilder.Entity("Assingnement.Domain.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bc4c27a3-b382-4e76-929b-0ea7c8118d3f"),
                            BirthDate = new DateTime(1990, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sevcan",
                            IsDeleted = false,
                            LastName = "Alkan"
                        },
                        new
                        {
                            Id = new Guid("8da05d93-1ae3-4bc4-b3b4-7a6ef582f168"),
                            BirthDate = new DateTime(1985, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ali",
                            IsDeleted = false,
                            LastName = "Bulut"
                        });
                });

            modelBuilder.Entity("Assingnement.Domain.Car", b =>
                {
                    b.HasOne("Assingnement.Domain.Model", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Assingnement.Domain.Owner", "Owner")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Assingnement.Domain.Model", b =>
                {
                    b.HasOne("Assingnement.Domain.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Assingnement.Domain.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Assingnement.Domain.Model", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Assingnement.Domain.Owner", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
