using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CardistryCloud.Models;

namespace CardistryCloud.Migrations
{
    [DbContext(typeof(CardistryCloudContext))]
    [Migration("20170728112703_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CardistryCloud.Models.Cardtrick", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Beschreibung");

                    b.Property<int>("Kategorie");

                    b.Property<int>("Schwierigkeitsgrad");

                    b.Property<string>("Titel");

                    b.HasKey("ID");

                    b.ToTable("Cardtrick");
                });
        }
    }
}
