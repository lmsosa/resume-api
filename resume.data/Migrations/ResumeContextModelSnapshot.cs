﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resume.Data.Context;

namespace Resume.Data.Migrations
{
    [DbContext(typeof(ResumeContext))]
    partial class ResumeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Resume.Domain.Entities.Curriculum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Curriculums");
                });

            modelBuilder.Entity("Resume.Domain.Entities.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurriculumId");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Resume.Domain.Entities.Educacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurriculumId");

                    b.Property<string>("Establecimiento");

                    b.Property<string>("Nivel")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CurriculumId");

                    b.ToTable("Educaciones");
                });

            modelBuilder.Entity("Resume.Domain.Entities.Experiencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cargo");

                    b.Property<int>("CurriculumId");

                    b.Property<string>("DescripcionTareas");

                    b.Property<string>("Empresa");

                    b.Property<DateTime?>("FechaFin");

                    b.Property<DateTime?>("FechaInicio");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumId");

                    b.ToTable("Experiencias");
                });

            modelBuilder.Entity("Resume.Domain.Entities.Curso", b =>
                {
                    b.HasOne("Resume.Domain.Entities.Curriculum")
                        .WithMany("Cursos")
                        .HasForeignKey("CurriculumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Resume.Domain.Entities.Educacion", b =>
                {
                    b.HasOne("Resume.Domain.Entities.Curriculum")
                        .WithMany("Educacion")
                        .HasForeignKey("CurriculumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Resume.Domain.Entities.Experiencia", b =>
                {
                    b.HasOne("Resume.Domain.Entities.Curriculum")
                        .WithMany("Experiencias")
                        .HasForeignKey("CurriculumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
