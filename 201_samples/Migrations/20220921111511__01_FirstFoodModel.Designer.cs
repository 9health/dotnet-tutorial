﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace _201_samples.Migrations
{
    [DbContext(typeof(FoodModel))]
    [Migration("20220921111511__01_FirstFoodModel")]
    partial class _01_FirstFoodModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("NHFoodVerF", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FoodSteps")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FoodTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FoodViews")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IngredientNum")
                        .HasColumnType("INTEGER");

                    b.HasKey("FoodId");

                    b.ToTable("Foods");
                });
#pragma warning restore 612, 618
        }
    }
}
