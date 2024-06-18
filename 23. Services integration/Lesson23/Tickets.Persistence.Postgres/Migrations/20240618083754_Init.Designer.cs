﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tickets.Persistence.Postgres;

#nullable disable

namespace Tickets.Persistence.Postgres.Migrations
{
    [DbContext(typeof(TicketsDbContext))]
    [Migration("20240618083754_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Tickets.Domain.Models.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("account_id");

                    b.Property<DateTime>("ActivationDate")
                        .HasColumnType("timestamp")
                        .HasColumnName("activation_date");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid")
                        .HasColumnName("client_id");

                    b.Property<DateTime?>("DeactivationDate")
                        .HasColumnType("timestamp")
                        .HasColumnName("deactivation_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<Guid>("TariffId")
                        .HasColumnType("uuid")
                        .HasColumnName("tariff_id");

                    b.HasKey("Id");

                    b.ToTable("tickets", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
