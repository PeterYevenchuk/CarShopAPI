﻿// <auto-generated />
using System;
using CarShop.Data_Access_Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(CarsDbContext))]
    [Migration("20230718120837_FixAdmin")]
    partial class FixAdmin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("DAL.Models.AddFunc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<bool>("GPSNavigation")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LeatherSeats")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ParkingSensors")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PremiumSoundSystem")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AdditionalFunctionalities");
                });

            modelBuilder.Entity("DAL.Models.AddFuncPrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CarId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ColorPrice")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("GPSNavigationPrice")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("LeatherSeatsPrice")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ParkingSensorsPrice")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PremiumSoundSystemPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("AdditionalFunctionalityPrices");
                });

            modelBuilder.Entity("DAL.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DateCreated")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("StandartColor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("DAL.Models.CarPhoto", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CarId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("URLPhoto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarPhotos");
                });

            modelBuilder.Entity("DAL.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AdditionalFunctionalityId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CarId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOrdered")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalFunctionalityId");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.Models.AddFuncPrice", b =>
                {
                    b.HasOne("DAL.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("DAL.Models.CarPhoto", b =>
                {
                    b.HasOne("DAL.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("DAL.Models.Order", b =>
                {
                    b.HasOne("DAL.Models.AddFunc", "AdditionalFunctionality")
                        .WithMany()
                        .HasForeignKey("AdditionalFunctionalityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DAL.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("AdditionalFunctionality");

                    b.Navigation("Car");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
