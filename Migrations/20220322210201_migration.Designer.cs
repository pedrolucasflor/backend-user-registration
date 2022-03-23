﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend_user_registration.Data;

namespace backend_user_registration.Migrations
{
    [DbContext(typeof(UserRegistrationContext))]
    [Migration("20220322210201_migration")]
    partial class migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("backend_user_registration.Models.Adress", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Userid");

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("backend_user_registration.Models.PhoneNumber", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Userid")
                        .HasColumnType("int");

                    b.Property<string>("label")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("Userid");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("backend_user_registration.Models.SocialMedia", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("facebookId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("instagramId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("linkedinId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("twitterId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("SocialMedia");
                });

            modelBuilder.Entity("backend_user_registration.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("birthdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("rg")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("socialMediaid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("socialMediaid");

                    b.ToTable("User");
                });

            modelBuilder.Entity("backend_user_registration.Models.Adress", b =>
                {
                    b.HasOne("backend_user_registration.Models.User", null)
                        .WithMany("adresses")
                        .HasForeignKey("Userid");
                });

            modelBuilder.Entity("backend_user_registration.Models.PhoneNumber", b =>
                {
                    b.HasOne("backend_user_registration.Models.User", null)
                        .WithMany("phoneNumbers")
                        .HasForeignKey("Userid");
                });

            modelBuilder.Entity("backend_user_registration.Models.User", b =>
                {
                    b.HasOne("backend_user_registration.Models.SocialMedia", "socialMedia")
                        .WithMany()
                        .HasForeignKey("socialMediaid");

                    b.Navigation("socialMedia");
                });

            modelBuilder.Entity("backend_user_registration.Models.User", b =>
                {
                    b.Navigation("adresses");

                    b.Navigation("phoneNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
