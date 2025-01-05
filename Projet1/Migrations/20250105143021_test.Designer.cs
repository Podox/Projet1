﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projet1.Data;

#nullable disable

namespace Projet1.Migrations
{
    [DbContext(typeof(Projet1Context))]
    [Migration("20250105143021_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projet1.Models.Adresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodePostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pays")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adresse");
                });

            modelBuilder.Entity("Projet1.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Contenu")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("DateDeCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("Projet1.Models.Domiciliation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdresseDomiciliationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdresseDomiciliationId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Domiciliation");
                });

            modelBuilder.Entity("Projet1.Models.Entreprise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdresseEId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdresseEId");

                    b.ToTable("Entreprise");
                });

            modelBuilder.Entity("Projet1.Models.Facture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateEcheance")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEmission")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntrepriseAssocieeId")
                        .HasColumnType("int");

                    b.Property<bool>("EstPayee")
                        .HasColumnType("bit");

                    b.Property<decimal>("MontantTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NumeroFacture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EntrepriseAssocieeId");

                    b.ToTable("Facture");
                });

            modelBuilder.Entity("Projet1.Models.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntrepriseUId")
                        .HasColumnType("int");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EntrepriseUId");

                    b.ToTable("Utilisateur");
                });

            modelBuilder.Entity("Projet1.Models.Domiciliation", b =>
                {
                    b.HasOne("Projet1.Models.Adresse", "AdresseDomiciliation")
                        .WithMany()
                        .HasForeignKey("AdresseDomiciliationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projet1.Models.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projet1.Models.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdresseDomiciliation");

                    b.Navigation("Document");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("Projet1.Models.Entreprise", b =>
                {
                    b.HasOne("Projet1.Models.Adresse", "Adresse")
                        .WithMany()
                        .HasForeignKey("AdresseEId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adresse");
                });

            modelBuilder.Entity("Projet1.Models.Facture", b =>
                {
                    b.HasOne("Projet1.Models.Entreprise", "EntrepriseAssociee")
                        .WithMany()
                        .HasForeignKey("EntrepriseAssocieeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntrepriseAssociee");
                });

            modelBuilder.Entity("Projet1.Models.Utilisateur", b =>
                {
                    b.HasOne("Projet1.Models.Entreprise", "Entreprise")
                        .WithMany()
                        .HasForeignKey("EntrepriseUId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entreprise");
                });
#pragma warning restore 612, 618
        }
    }
}
