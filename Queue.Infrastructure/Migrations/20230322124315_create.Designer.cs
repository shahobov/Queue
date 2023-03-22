﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Queue.Infrastructure.Persistence.Database;

#nullable disable

namespace Queue.Infrastructure.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20230322124315_create")]
    partial class create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Queue.Domain.Model.Job", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("Queue.Domain.Model.Person", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Age")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("Gender")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("Queue.Domain.Model.QueueForService", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("ClientId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("PositionQueueId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("QueueStatus")
                        .HasColumnType("integer");

                    b.Property<decimal>("ServiceId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("WorkerId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("WorkerId");

                    b.ToTable("QueueForService", (string)null);
                });

            modelBuilder.Entity("Queue.Domain.Model.Service", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("Queue.Domain.Model.Client", b =>
                {
                    b.HasBaseType("Queue.Domain.Model.Person");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("Queue.Domain.Model.Worker", b =>
                {
                    b.HasBaseType("Queue.Domain.Model.Person");

                    b.Property<decimal?>("JobId")
                        .HasColumnType("numeric(20,0)");

                    b.HasIndex("JobId");

                    b.ToTable("Worker", (string)null);
                });

            modelBuilder.Entity("Queue.Domain.Model.QueueForService", b =>
                {
                    b.HasOne("Queue.Domain.Model.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Queue.Domain.Model.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Queue.Domain.Model.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Service");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Queue.Domain.Model.Client", b =>
                {
                    b.HasOne("Queue.Domain.Model.Person", null)
                        .WithOne()
                        .HasForeignKey("Queue.Domain.Model.Client", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Queue.Domain.Model.Worker", b =>
                {
                    b.HasOne("Queue.Domain.Model.Person", null)
                        .WithOne()
                        .HasForeignKey("Queue.Domain.Model.Worker", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Queue.Domain.Model.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId");

                    b.Navigation("Job");
                });
#pragma warning restore 612, 618
        }
    }
}
