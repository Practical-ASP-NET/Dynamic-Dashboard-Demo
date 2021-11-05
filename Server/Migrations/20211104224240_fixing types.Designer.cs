﻿// <auto-generated />
using System;
using DynamicDashboards.Server.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DynamicDashboards.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211104224240_fixing types")]
    partial class fixingtypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0-rc.2.21480.5");

            modelBuilder.Entity("DynamicDashboards.Server.Domain.Dashboards.Dashboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Dashboards");
                });

            modelBuilder.Entity("DynamicDashboards.Server.Domain.Dashboards.Panel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ComponentType")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DashboardId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DashboardId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DashboardId");

                    b.HasIndex("DashboardId1");

                    b.ToTable("Panel");
                });

            modelBuilder.Entity("DynamicDashboards.Server.Domain.Dashboards.Panel", b =>
                {
                    b.HasOne("DynamicDashboards.Server.Domain.Dashboards.Dashboard", null)
                        .WithMany("Panels")
                        .HasForeignKey("DashboardId");

                    b.HasOne("DynamicDashboards.Server.Domain.Dashboards.Dashboard", null)
                        .WithMany()
                        .HasForeignKey("DashboardId1");
                });

            modelBuilder.Entity("DynamicDashboards.Server.Domain.Dashboards.Dashboard", b =>
                {
                    b.Navigation("Panels");
                });
#pragma warning restore 612, 618
        }
    }
}