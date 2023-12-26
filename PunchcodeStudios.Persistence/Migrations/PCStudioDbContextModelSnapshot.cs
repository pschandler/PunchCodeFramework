﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PunchcodeStudios.Persistence.DatabaseContext;

#nullable disable

namespace PunchcodeStudios.Persistence.Migrations
{
    [DbContext(typeof(PCStudioDbContext))]
    partial class PCStudioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryGallery", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GalleriesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesId", "GalleriesId");

                    b.HasIndex("GalleriesId");

                    b.ToTable("CategoryGallery");
                });

            modelBuilder.Entity("PunchcodeStudios.Domain.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PunchcodeStudios.Domain.CategoryGallery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GalleriesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoriesId");

                    b.HasIndex("GalleriesId");

                    b.ToTable("CategoryGalleries", (string)null);
                });

            modelBuilder.Entity("PunchcodeStudios.Domain.Gallery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("GalleryTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("GalleryTypeId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Galleries");
                });

            modelBuilder.Entity("PunchcodeStudios.Domain.GalleryType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GalleryTypes");
                });

            modelBuilder.Entity("CategoryGallery", b =>
                {
                    b.HasOne("PunchcodeStudios.Domain.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PunchcodeStudios.Domain.Gallery", null)
                        .WithMany()
                        .HasForeignKey("GalleriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PunchcodeStudios.Domain.CategoryGallery", b =>
                {
                    b.HasOne("PunchcodeStudios.Domain.Category", "Category")
                        .WithMany("CategoryGalleries")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PunchcodeStudios.Domain.Gallery", "Gallery")
                        .WithMany("CategoryGalleries")
                        .HasForeignKey("GalleriesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Gallery");
                });

            modelBuilder.Entity("PunchcodeStudios.Domain.Gallery", b =>
                {
                    b.HasOne("PunchcodeStudios.Domain.GalleryType", "Type")
                        .WithMany("Galleries")
                        .HasForeignKey("GalleryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("PunchcodeStudios.Domain.Category", b =>
                {
                    b.Navigation("CategoryGalleries");
                });

            modelBuilder.Entity("PunchcodeStudios.Domain.Gallery", b =>
                {
                    b.Navigation("CategoryGalleries");
                });

            modelBuilder.Entity("PunchcodeStudios.Domain.GalleryType", b =>
                {
                    b.Navigation("Galleries");
                });
#pragma warning restore 612, 618
        }
    }
}
