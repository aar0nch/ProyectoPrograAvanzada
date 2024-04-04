﻿// <auto-generated />
using MVCHotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCHotel.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240403185452_inicial2")]
    partial class inicial2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVCHotel.Models.CategoriaProducto", b =>
                {
                    b.Property<int>("idCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCategoria"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idCategoria");

                    b.ToTable("CategoriasProducto");
                });

            modelBuilder.Entity("MVCHotel.Models.Producto", b =>
                {
                    b.Property<int>("idProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idProducto"));

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<string>("descripcionProducto")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("idCategoria")
                        .HasColumnType("int");

                    b.Property<byte[]>("imagen")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("nombreProducto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("precioProducto")
                        .HasColumnType("real");

                    b.HasKey("idProducto");

                    b.HasIndex("idCategoria");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("MVCHotel.Models.Producto", b =>
                {
                    b.HasOne("MVCHotel.Models.CategoriaProducto", "categoriaProducto")
                        .WithMany("Productos")
                        .HasForeignKey("idCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoriaProducto");
                });

            modelBuilder.Entity("MVCHotel.Models.CategoriaProducto", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}