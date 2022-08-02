﻿// <auto-generated />
using System;
using DbContextProfi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbContextProfi.Migrations
{
    [DbContext(typeof(DbContextProfiСonnector))]
    [Migration("20220721132659_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.HasSequence<int>("ApplicationNumbers");

            modelBuilder.Entity("Resources.Entities.ApplicationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateReceipt")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date_receipt_application");

                    b.Property<string>("GuestEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Guest_email");

                    b.Property<string>("GuestName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("Guest_name");

                    b.Property<string>("GuestsApplicationText")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("Guests_application_text");

                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Application_number")
                        .HasDefaultValueSql("NEXT VALUE FOR ApplicationNumbers");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint")
                        .HasColumnName("Application_processing_status");

                    b.HasKey("Id");

                    b.ToTable("Guests_applications");
                });

            modelBuilder.Entity("Resources.Entities.BlogEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("BlogImageAsArray64")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Blog_image");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit")
                        .HasColumnName("Is_published");

                    b.Property<string>("LongBlogDescription")
                        .IsRequired()
                        .HasMaxLength(6000)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Long_description");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Creation_date");

                    b.Property<string>("ShortBlogDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Short_description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Resources.Entities.ContactEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Address");

                    b.Property<string>("Fax")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Fax");

                    b.Property<bool>("IsPublishedOnMainPage")
                        .HasColumnType("bit")
                        .HasColumnName("Is_posted_on_the_page");

                    b.Property<byte[]>("MapAsArray64")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Map");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Phone");

                    b.Property<int>("Postcode")
                        .HasColumnType("int")
                        .HasColumnName("Postcode");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Resources.Entities.HeaderMenuSetEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Blogs")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("Menu_items_blogs");

                    b.Property<string>("Contacts")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("Menu_items_contacts");

                    b.Property<bool>("IsPublishedOnMainPage")
                        .HasColumnType("bit")
                        .HasColumnName("Is_posted_on_the_page");

                    b.Property<string>("Main")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("Menu_items_main");

                    b.Property<string>("Projects")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("Menu_items_projects");

                    b.Property<string>("Services")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("Menu_items_services");

                    b.HasKey("Id");

                    b.ToTable("Menu_sets");
                });

            modelBuilder.Entity("Resources.Entities.HeaderSloganEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit")
                        .HasColumnName("Slogan_used");

                    b.Property<string>("Slogan")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)")
                        .HasColumnName("Slogans");

                    b.HasKey("Id");

                    b.ToTable("Header_slogans");
                });

            modelBuilder.Entity("Resources.Entities.MainPageActionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("Actions");

                    b.HasKey("Id");

                    b.ToTable("Page_actions");
                });

            modelBuilder.Entity("Resources.Entities.MainPageButtonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Button")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("Buttons");

                    b.HasKey("Id");

                    b.ToTable("Page_buttons");
                });

            modelBuilder.Entity("Resources.Entities.MainPageImageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("ImageAsArray64")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Image");

                    b.HasKey("Id");

                    b.ToTable("Page_images");
                });

            modelBuilder.Entity("Resources.Entities.MainPagePhraseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Phrase")
                        .IsRequired()
                        .HasMaxLength(44)
                        .HasColumnType("nvarchar(44)")
                        .HasColumnName("Phrases");

                    b.HasKey("Id");

                    b.ToTable("Page_phrases");
                });

            modelBuilder.Entity("Resources.Entities.MainPagePresetEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ActionId")
                        .HasColumnType("int")
                        .HasColumnName("Action_id");

                    b.Property<int?>("ButtonId")
                        .HasColumnType("int")
                        .HasColumnName("Button_id");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int")
                        .HasColumnName("Image_id");

                    b.Property<bool>("IsPublishedOnMainPage")
                        .HasColumnType("bit")
                        .HasColumnName("Is_posted_on_the_page");

                    b.Property<int?>("PhraseId")
                        .HasColumnType("int")
                        .HasColumnName("Phrase_id");

                    b.Property<string>("PresetName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Preset_name");

                    b.Property<int?>("TextId")
                        .HasColumnType("int")
                        .HasColumnName("Text_id");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("ButtonId");

                    b.HasIndex("ImageId");

                    b.HasIndex("PhraseId");

                    b.HasIndex("TextId");

                    b.ToTable("Main_page_presets");
                });

            modelBuilder.Entity("Resources.Entities.MainPageTextEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("Text");

                    b.HasKey("Id");

                    b.ToTable("Page_texts");
                });

            modelBuilder.Entity("Resources.Entities.ProjectEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("CustomerCompanyLogoAsArray64")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Customer_company_logo");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit")
                        .HasColumnName("Is_published");

                    b.Property<string>("LinkToCustomerSite")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Link_to_customer_site");

                    b.Property<string>("ProjectDescription")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Project_article");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Resources.Entities.ServiceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit")
                        .HasColumnName("Is_published");

                    b.Property<string>("ServiceDescription")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)")
                        .HasColumnName("Service_description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Resources.Entities.MainPagePresetEntity", b =>
                {
                    b.HasOne("Resources.Entities.MainPageActionEntity", "Action")
                        .WithMany("Presets")
                        .HasForeignKey("ActionId");

                    b.HasOne("Resources.Entities.MainPageButtonEntity", "Button")
                        .WithMany("Presets")
                        .HasForeignKey("ButtonId");

                    b.HasOne("Resources.Entities.MainPageImageEntity", "Image")
                        .WithMany("Presets")
                        .HasForeignKey("ImageId");

                    b.HasOne("Resources.Entities.MainPagePhraseEntity", "Phrase")
                        .WithMany("Presets")
                        .HasForeignKey("PhraseId");

                    b.HasOne("Resources.Entities.MainPageTextEntity", "Text")
                        .WithMany("Presets")
                        .HasForeignKey("TextId");

                    b.Navigation("Action");

                    b.Navigation("Button");

                    b.Navigation("Image");

                    b.Navigation("Phrase");

                    b.Navigation("Text");
                });

            modelBuilder.Entity("Resources.Entities.MainPageActionEntity", b =>
                {
                    b.Navigation("Presets");
                });

            modelBuilder.Entity("Resources.Entities.MainPageButtonEntity", b =>
                {
                    b.Navigation("Presets");
                });

            modelBuilder.Entity("Resources.Entities.MainPageImageEntity", b =>
                {
                    b.Navigation("Presets");
                });

            modelBuilder.Entity("Resources.Entities.MainPagePhraseEntity", b =>
                {
                    b.Navigation("Presets");
                });

            modelBuilder.Entity("Resources.Entities.MainPageTextEntity", b =>
                {
                    b.Navigation("Presets");
                });
#pragma warning restore 612, 618
        }
    }
}
