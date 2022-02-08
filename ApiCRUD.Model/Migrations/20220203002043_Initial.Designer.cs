﻿// <auto-generated />
using ApiCRUD;
using ApiCRUD.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiCRUD.Migrations
{
    [DbContext(typeof(VehicleContext))]
    [Migration("20220203002043_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19");

            modelBuilder.Entity("ApiCRUD.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsOn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WheelSize")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("ApiCRUD.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsOn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WheelSize")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("ApiCRUD.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsOn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WheelSize")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Trucks");
                });
#pragma warning restore 612, 618
        }
    }
}