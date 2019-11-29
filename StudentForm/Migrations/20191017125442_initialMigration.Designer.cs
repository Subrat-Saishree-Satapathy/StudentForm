﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentForm.Models;

namespace StudentForm.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20191017125442_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("StudentForm.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Addresslocation");

                    b.Property<int>("Pincode");

                    b.Property<int>("StudentID");

                    b.HasKey("AddressId");

                    b.HasIndex("StudentID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("StudentForm.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StudentName");

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentForm.Models.Address", b =>
                {
                    b.HasOne("StudentForm.Models.Student", "Student")
                        .WithMany("Address")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
