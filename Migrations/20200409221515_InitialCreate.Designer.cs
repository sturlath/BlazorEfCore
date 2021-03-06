﻿// <auto-generated />
using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorEfCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200409221515_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.MySettings", b =>
                {
                    b.Property<int>("MySettingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalSystemId")
                        .HasColumnType("int");

                    b.HasKey("MySettingsId");

                    b.HasIndex("PostalSystemId")
                        .IsUnique();

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Entities.PostalSystem", b =>
                {
                    b.Property<int>("PostalSystemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostalSystemId");

                    b.ToTable("PostalSystem");
                });

            modelBuilder.Entity("Entities.MySettings", b =>
                {
                    b.HasOne("Entities.PostalSystem", "PostalSystem")
                        .WithOne("MySettings")
                        .HasForeignKey("Entities.MySettings", "PostalSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
