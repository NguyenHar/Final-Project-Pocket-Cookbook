﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pocket_Cookbook_Backend.Models;

#nullable disable

namespace Pocket_Cookbook_Backend.Migrations
{
    [DbContext(typeof(CookbookContext))]
    [Migration("20230619151647_querymigration")]
    partial class querymigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Analyzedinstruction", b =>
                {
                    b.Property<int>("primary_key_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("primary_key_id"));

                    b.Property<int>("RecipeFK")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("primary_key_id");

                    b.HasIndex("RecipeFK");

                    b.ToTable("analyzedinstructions");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Equipment", b =>
                {
                    b.Property<int>("primary_key_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("primary_key_id"));

                    b.Property<int>("StepFK")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("localizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("primary_key_id");

                    b.HasIndex("StepFK");

                    b.ToTable("equipment");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Extendedingredient", b =>
                {
                    b.Property<int>("primary_key_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("primary_key_id"));

                    b.Property<int>("RecipeFK")
                        .HasColumnType("int");

                    b.Property<string>("aisle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("amount")
                        .HasColumnType("real");

                    b.Property<string>("consistency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("measuresprimary_key_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameClean")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("original")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("originalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("primary_key_id");

                    b.HasIndex("RecipeFK");

                    b.HasIndex("measuresprimary_key_id");

                    b.ToTable("extendedingredients");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Ingredient", b =>
                {
                    b.Property<int>("primary_key_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("primary_key_id"));

                    b.Property<int>("StepFK")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("localizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("primary_key_id");

                    b.HasIndex("StepFK");

                    b.ToTable("ingredients");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Meal", b =>
                {
                    b.Property<int>("primary_key_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("primary_key_id"));

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int?>("number")
                        .HasColumnType("int");

                    b.Property<int?>("offset")
                        .HasColumnType("int");

                    b.Property<int?>("totalResults")
                        .HasColumnType("int");

                    b.HasKey("primary_key_id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Measures", b =>
                {
                    b.Property<int>("primary_key_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("primary_key_id"));

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int?>("metricprimary_key_id")
                        .HasColumnType("int");

                    b.Property<int?>("usprimary_key_id")
                        .HasColumnType("int");

                    b.HasKey("primary_key_id");

                    b.HasIndex("metricprimary_key_id");

                    b.HasIndex("usprimary_key_id");

                    b.ToTable("measures");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Metric", b =>
                {
                    b.Property<int>("primary_key_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("primary_key_id"));

                    b.Property<float?>("amount")
                        .HasColumnType("real");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("unitLong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitShort")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("primary_key_id");

                    b.ToTable("units_metric");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Queries", b =>
                {
                    b.Property<int>("primary_key_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("primary_key_id"));

                    b.Property<int>("mealFK")
                        .HasColumnType("int");

                    b.Property<string>("query")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("time")
                        .HasColumnType("int");

                    b.HasKey("primary_key_id");

                    b.HasIndex("mealFK");

                    b.ToTable("Queries");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Recipe", b =>
                {
                    b.Property<int>("primary_key_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("primary_key_id"));

                    b.Property<int?>("aggregateLikes")
                        .HasColumnType("int");

                    b.Property<bool?>("cheap")
                        .HasColumnType("bit");

                    b.Property<int?>("cookingMinutes")
                        .HasColumnType("int");

                    b.Property<string>("creditsText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("dairyFree")
                        .HasColumnType("bit");

                    b.Property<string>("gaps")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("glutenFree")
                        .HasColumnType("bit");

                    b.Property<int?>("healthScore")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("instructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("lowFodmap")
                        .HasColumnType("bit");

                    b.Property<int?>("preparationMinutes")
                        .HasColumnType("int");

                    b.Property<float?>("pricePerServing")
                        .HasColumnType("real");

                    b.Property<int?>("readyInMinutes")
                        .HasColumnType("int");

                    b.Property<int?>("servings")
                        .HasColumnType("int");

                    b.Property<string>("sourceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sourceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spoonacularSourceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("sustainable")
                        .HasColumnType("bit");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("vegan")
                        .HasColumnType("bit");

                    b.Property<bool?>("vegetarian")
                        .HasColumnType("bit");

                    b.Property<bool?>("veryHealthy")
                        .HasColumnType("bit");

                    b.Property<bool?>("veryPopular")
                        .HasColumnType("bit");

                    b.Property<int?>("weightWatcherSmartPoints")
                        .HasColumnType("int");

                    b.HasKey("primary_key_id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Result", b =>
                {
                    b.Property<int>("primary_key_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("primary_key_id"));

                    b.Property<int?>("Meal")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("primary_key_id");

                    b.HasIndex("Meal");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Step", b =>
                {
                    b.Property<int>("primary_key_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("primary_key_id"));

                    b.Property<int>("AnalyzedInstructionFK")
                        .HasColumnType("int");

                    b.Property<int?>("AnalyzedInstructionprimary_key_id")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int?>("number")
                        .HasColumnType("int");

                    b.Property<string>("step")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("primary_key_id");

                    b.HasIndex("AnalyzedInstructionprimary_key_id");

                    b.ToTable("steps");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Us", b =>
                {
                    b.Property<int>("primary_key_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("primary_key_id"));

                    b.Property<float?>("amount")
                        .HasColumnType("real");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("unitLong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitShort")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("primary_key_id");

                    b.ToTable("units_us");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Analyzedinstruction", b =>
                {
                    b.HasOne("Pocket_Cookbook_Backend.Models.Recipe", "Recipe")
                        .WithMany("analyzedInstructions")
                        .HasForeignKey("RecipeFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Equipment", b =>
                {
                    b.HasOne("Pocket_Cookbook_Backend.Models.Step", "Step")
                        .WithMany("equipment")
                        .HasForeignKey("StepFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Step");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Extendedingredient", b =>
                {
                    b.HasOne("Pocket_Cookbook_Backend.Models.Recipe", "Recipe")
                        .WithMany("extendedIngredients")
                        .HasForeignKey("RecipeFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pocket_Cookbook_Backend.Models.Measures", "measures")
                        .WithMany()
                        .HasForeignKey("measuresprimary_key_id");

                    b.Navigation("Recipe");

                    b.Navigation("measures");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Ingredient", b =>
                {
                    b.HasOne("Pocket_Cookbook_Backend.Models.Step", "Step")
                        .WithMany("ingredients")
                        .HasForeignKey("StepFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Step");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Measures", b =>
                {
                    b.HasOne("Pocket_Cookbook_Backend.Models.Metric", "metric")
                        .WithMany()
                        .HasForeignKey("metricprimary_key_id");

                    b.HasOne("Pocket_Cookbook_Backend.Models.Us", "us")
                        .WithMany()
                        .HasForeignKey("usprimary_key_id");

                    b.Navigation("metric");

                    b.Navigation("us");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Queries", b =>
                {
                    b.HasOne("Pocket_Cookbook_Backend.Models.Meal", "meal")
                        .WithMany()
                        .HasForeignKey("mealFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("meal");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Result", b =>
                {
                    b.HasOne("Pocket_Cookbook_Backend.Models.Meal", "meal")
                        .WithMany("results")
                        .HasForeignKey("Meal");

                    b.Navigation("meal");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Step", b =>
                {
                    b.HasOne("Pocket_Cookbook_Backend.Models.Analyzedinstruction", "AnalyzedInstruction")
                        .WithMany("steps")
                        .HasForeignKey("AnalyzedInstructionprimary_key_id");

                    b.Navigation("AnalyzedInstruction");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Analyzedinstruction", b =>
                {
                    b.Navigation("steps");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Meal", b =>
                {
                    b.Navigation("results");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Recipe", b =>
                {
                    b.Navigation("analyzedInstructions");

                    b.Navigation("extendedIngredients");
                });

            modelBuilder.Entity("Pocket_Cookbook_Backend.Models.Step", b =>
                {
                    b.Navigation("equipment");

                    b.Navigation("ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
