﻿// <auto-generated />
using FlasherData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlasherData.Migrations
{
    [DbContext(typeof(FlasherContext))]
    [Migration("20211018184202_three")]
    partial class three
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("FlasherApi.Data.Models.Flashcard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AnsweredCorrectly")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Back")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Front")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Set")
                        .HasColumnType("TEXT");

                    b.Property<int>("SetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Superset")
                        .HasColumnType("TEXT");

                    b.Property<int>("SupersetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SetId");

                    b.HasIndex("SupersetId");

                    b.ToTable("FlashCards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnsweredCorrectly = false,
                            Back = "Back1",
                            Front = "Front1",
                            Set = "Set1",
                            SetId = 1,
                            Superset = "Superset1",
                            SupersetId = 1,
                            Title = "FlashCard1"
                        },
                        new
                        {
                            Id = 2,
                            AnsweredCorrectly = false,
                            Back = "Back2",
                            Front = "Front2",
                            Set = "Set1",
                            SetId = 1,
                            Superset = "Superset1",
                            SupersetId = 1,
                            Title = "FlashCard2"
                        },
                        new
                        {
                            Id = 3,
                            AnsweredCorrectly = false,
                            Back = "Back3",
                            Front = "Front3",
                            Set = "Set2",
                            SetId = 2,
                            Superset = "Superset1",
                            SupersetId = 1,
                            Title = "FlashCard3"
                        },
                        new
                        {
                            Id = 4,
                            AnsweredCorrectly = false,
                            Back = "Back4",
                            Front = "Front4",
                            Set = "Set2",
                            SetId = 2,
                            Superset = "Superset1",
                            SupersetId = 1,
                            Title = "FlashCard4"
                        },
                        new
                        {
                            Id = 5,
                            AnsweredCorrectly = false,
                            Back = "Back5",
                            Front = "Front5",
                            Set = "Set3",
                            SetId = 3,
                            Superset = "Superset2",
                            SupersetId = 2,
                            Title = "FlashCard5"
                        },
                        new
                        {
                            Id = 6,
                            AnsweredCorrectly = false,
                            Back = "Back6",
                            Front = "Front5",
                            Set = "Set3",
                            SetId = 3,
                            Superset = "Superset2",
                            SupersetId = 2,
                            Title = "FlashCard6"
                        },
                        new
                        {
                            Id = 7,
                            AnsweredCorrectly = false,
                            Back = "Back7",
                            Front = "Front7",
                            Set = "Set4",
                            SetId = 4,
                            Superset = "Superset2",
                            SupersetId = 2,
                            Title = "FlashCard7"
                        },
                        new
                        {
                            Id = 8,
                            AnsweredCorrectly = false,
                            Back = "Back8",
                            Front = "Front8",
                            Set = "Set4",
                            SetId = 4,
                            Superset = "Superset2",
                            SupersetId = 2,
                            Title = "FlashCard8"
                        });
                });

            modelBuilder.Entity("FlasherApi.Data.Models.Set", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Set1"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Set2"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Set3"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Set4"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Set5"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Set6"
                        },
                        new
                        {
                            Id = 7,
                            Title = "Set7"
                        },
                        new
                        {
                            Id = 8,
                            Title = "Set8"
                        });
                });

            modelBuilder.Entity("FlasherApi.Data.Models.Superset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Supersets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Superset1"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Superset2"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Superset3"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Superset4"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Superset5"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Superset6"
                        },
                        new
                        {
                            Id = 7,
                            Title = "Superset7"
                        },
                        new
                        {
                            Id = 8,
                            Title = "Superset8"
                        });
                });

            modelBuilder.Entity("FlasherApi.Data.Models.Flashcard", b =>
                {
                    b.HasOne("FlasherApi.Data.Models.Set", null)
                        .WithMany("FlashCards")
                        .HasForeignKey("SetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlasherApi.Data.Models.Superset", null)
                        .WithMany("FlashCards")
                        .HasForeignKey("SupersetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlasherApi.Data.Models.Set", b =>
                {
                    b.Navigation("FlashCards");
                });

            modelBuilder.Entity("FlasherApi.Data.Models.Superset", b =>
                {
                    b.Navigation("FlashCards");
                });
#pragma warning restore 612, 618
        }
    }
}
