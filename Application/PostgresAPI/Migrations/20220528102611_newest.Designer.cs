﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PostgresAPI.Context;

#nullable disable

namespace PostgresAPI.Migrations
{
    [DbContext(typeof(DbApplicationContext))]
    [Migration("20220528102611_newest")]
    partial class newest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PostgresAPI.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityInfoId")
                        .HasColumnType("integer");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityInfoId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityInfoId = 1,
                            StreetName = "Skovvej"
                        },
                        new
                        {
                            Id = 2,
                            CityInfoId = 1,
                            StreetName = "Hovmarksvej"
                        });
                });

            modelBuilder.Entity("PostgresAPI.Models.CityInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CityInfos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Gentofte",
                            ZipCode = "2920"
                        });
                });

            modelBuilder.Entity("PostgresAPI.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = 1
                        },
                        new
                        {
                            Id = 2
                        });
                });

            modelBuilder.Entity("PostgresAPI.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MenuId")
                        .HasColumnType("integer");

                    b.Property<int>("MenuItemTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("MenuItemTypeId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MenuId = 1,
                            MenuItemTypeId = 3,
                            Name = "salatpizza",
                            Price = 79.989999999999995
                        },
                        new
                        {
                            Id = 2,
                            MenuId = 1,
                            MenuItemTypeId = 3,
                            Name = "Peperoni",
                            Price = 79.230000000000004
                        },
                        new
                        {
                            Id = 3,
                            MenuId = 1,
                            MenuItemTypeId = 3,
                            Name = "Calzone",
                            Price = 89.989999999999995
                        },
                        new
                        {
                            Id = 4,
                            MenuId = 1,
                            MenuItemTypeId = 2,
                            Name = "ChokoladeIs",
                            Price = 39.990000000000002
                        },
                        new
                        {
                            Id = 5,
                            MenuId = 1,
                            MenuItemTypeId = 2,
                            Name = "vaniljeis",
                            Price = 39.990000000000002
                        },
                        new
                        {
                            Id = 6,
                            MenuId = 1,
                            MenuItemTypeId = 2,
                            Name = "chokoladekage",
                            Price = 39.990000000000002
                        },
                        new
                        {
                            Id = 7,
                            MenuId = 1,
                            MenuItemTypeId = 4,
                            Name = "Cola",
                            Price = 19.989999999999998
                        },
                        new
                        {
                            Id = 8,
                            MenuId = 1,
                            MenuItemTypeId = 4,
                            Name = "Fanta",
                            Price = 19.989999999999998
                        },
                        new
                        {
                            Id = 9,
                            MenuId = 1,
                            MenuItemTypeId = 1,
                            Name = "Mayo",
                            Price = 9.9900000000000002
                        },
                        new
                        {
                            Id = 10,
                            MenuId = 1,
                            MenuItemTypeId = 1,
                            Name = "Ketchup",
                            Price = 9.9900000000000002
                        },
                        new
                        {
                            Id = 11,
                            MenuId = 2,
                            MenuItemTypeId = 3,
                            Name = "laks",
                            Price = 79.989999999999995
                        },
                        new
                        {
                            Id = 12,
                            MenuId = 2,
                            MenuItemTypeId = 3,
                            Name = "tun",
                            Price = 79.230000000000004
                        },
                        new
                        {
                            Id = 13,
                            MenuId = 2,
                            MenuItemTypeId = 3,
                            Name = "krabbe",
                            Price = 89.989999999999995
                        },
                        new
                        {
                            Id = 14,
                            MenuId = 2,
                            MenuItemTypeId = 2,
                            Name = "ChokoladeIs",
                            Price = 39.990000000000002
                        },
                        new
                        {
                            Id = 15,
                            MenuId = 2,
                            MenuItemTypeId = 2,
                            Name = "vaniljeis",
                            Price = 39.990000000000002
                        },
                        new
                        {
                            Id = 16,
                            MenuId = 2,
                            MenuItemTypeId = 2,
                            Name = "chokoladekage",
                            Price = 39.990000000000002
                        },
                        new
                        {
                            Id = 17,
                            MenuId = 2,
                            MenuItemTypeId = 4,
                            Name = "Cola",
                            Price = 19.989999999999998
                        },
                        new
                        {
                            Id = 18,
                            MenuId = 2,
                            MenuItemTypeId = 4,
                            Name = "Fanta",
                            Price = 19.989999999999998
                        },
                        new
                        {
                            Id = 19,
                            MenuId = 2,
                            MenuItemTypeId = 1,
                            Name = "Mayo",
                            Price = 9.9900000000000002
                        },
                        new
                        {
                            Id = 20,
                            MenuId = 2,
                            MenuItemTypeId = 1,
                            Name = "Ketchup",
                            Price = 9.9900000000000002
                        });
                });

            modelBuilder.Entity("PostgresAPI.Models.MenuItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("MenuItemTypeChoice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MenuItemTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MenuItemTypeChoice = "AddOn"
                        },
                        new
                        {
                            Id = 2,
                            MenuItemTypeChoice = "Dessert"
                        },
                        new
                        {
                            Id = 3,
                            MenuItemTypeChoice = "Food"
                        },
                        new
                        {
                            Id = 4,
                            MenuItemTypeChoice = "Drink"
                        });
                });

            modelBuilder.Entity("PostgresAPI.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<int>("MenuId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ResturantTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("MenuId")
                        .IsUnique();

                    b.HasIndex("ResturantTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            MenuId = 1,
                            Name = "PizzaPusheren",
                            ResturantTypeId = 15,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            MenuId = 2,
                            Name = "SushiSlyngeren",
                            ResturantTypeId = 16,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("PostgresAPI.Models.RestaurantType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("RestaurantTypeChoice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RestaurantTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RestaurantTypeChoice = "Salat"
                        },
                        new
                        {
                            Id = 2,
                            RestaurantTypeChoice = "Cafe"
                        },
                        new
                        {
                            Id = 3,
                            RestaurantTypeChoice = "Vietnamese"
                        },
                        new
                        {
                            Id = 4,
                            RestaurantTypeChoice = "Vegan"
                        },
                        new
                        {
                            Id = 5,
                            RestaurantTypeChoice = "Mexican"
                        },
                        new
                        {
                            Id = 6,
                            RestaurantTypeChoice = "Bagel"
                        },
                        new
                        {
                            Id = 7,
                            RestaurantTypeChoice = "Bar"
                        },
                        new
                        {
                            Id = 8,
                            RestaurantTypeChoice = "Burger"
                        },
                        new
                        {
                            Id = 9,
                            RestaurantTypeChoice = "Chinese"
                        },
                        new
                        {
                            Id = 10,
                            RestaurantTypeChoice = "Danish"
                        },
                        new
                        {
                            Id = 11,
                            RestaurantTypeChoice = "Dessert"
                        },
                        new
                        {
                            Id = 12,
                            RestaurantTypeChoice = "Icecream"
                        },
                        new
                        {
                            Id = 13,
                            RestaurantTypeChoice = "Indian"
                        },
                        new
                        {
                            Id = 14,
                            RestaurantTypeChoice = "Italian"
                        },
                        new
                        {
                            Id = 15,
                            RestaurantTypeChoice = "Pizza"
                        },
                        new
                        {
                            Id = 16,
                            RestaurantTypeChoice = "Sushi"
                        },
                        new
                        {
                            Id = 17,
                            RestaurantTypeChoice = "Sandwich"
                        },
                        new
                        {
                            Id = 18,
                            RestaurantTypeChoice = "Thai"
                        });
                });

            modelBuilder.Entity("PostgresAPI.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleType = "Customer"
                        },
                        new
                        {
                            Id = 2,
                            RoleType = "Owner"
                        });
                });

            modelBuilder.Entity("PostgresAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2022, 5, 28, 10, 26, 10, 471, DateTimeKind.Utc).AddTicks(7289));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 5, 28, 10, 26, 10, 471, DateTimeKind.Utc).AddTicks(7632),
                            Email = "Niels@Andersen.dk",
                            LastName = "Andersen",
                            Name = "Niels",
                            Password = "$2a$11$A3NfmwsL1FOfWfI6O5jMBelwbYuJ0nLkwuZtJ6MeQAG22gnNOwqmq",
                            PhoneNumber = "44334455",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 5, 28, 10, 26, 10, 582, DateTimeKind.Utc).AddTicks(7996),
                            Email = "Restaurant@Ejer.dk",
                            LastName = "Ejer",
                            Name = "Restaurant",
                            Password = "$2a$11$IDNgvNGnQKJNoQrp3cqn..UBkF3Su/RbJsKatAoBaw.9WwbzntIA6",
                            PhoneNumber = "44334422",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 5, 28, 10, 26, 10, 697, DateTimeKind.Utc).AddTicks(5217),
                            Email = "Restaurant@Ejer2.dk",
                            LastName = "Ejer2",
                            Name = "Restaurant2",
                            Password = "$2a$11$5d/70vDxe6ESkl8Xg0tzku6UBbqeOLlZKahx3/FHojzv2P1lwutca",
                            PhoneNumber = "44334432",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("PostgresAPI.Models.Address", b =>
                {
                    b.HasOne("PostgresAPI.Models.CityInfo", "CityInfo")
                        .WithMany("Addresses")
                        .HasForeignKey("CityInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityInfo");
                });

            modelBuilder.Entity("PostgresAPI.Models.MenuItem", b =>
                {
                    b.HasOne("PostgresAPI.Models.Menu", "Menu")
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PostgresAPI.Models.MenuItemType", "MenuItemType")
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("MenuItemType");
                });

            modelBuilder.Entity("PostgresAPI.Models.Restaurant", b =>
                {
                    b.HasOne("PostgresAPI.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PostgresAPI.Models.Menu", "Menu")
                        .WithOne("Restaurant")
                        .HasForeignKey("PostgresAPI.Models.Restaurant", "MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PostgresAPI.Models.RestaurantType", "ResturantType")
                        .WithMany("Restaurants")
                        .HasForeignKey("ResturantTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PostgresAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Menu");

                    b.Navigation("ResturantType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PostgresAPI.Models.User", b =>
                {
                    b.HasOne("PostgresAPI.Models.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PostgresAPI.Models.CityInfo", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("PostgresAPI.Models.Menu", b =>
                {
                    b.Navigation("MenuItems");

                    b.Navigation("Restaurant")
                        .IsRequired();
                });

            modelBuilder.Entity("PostgresAPI.Models.MenuItemType", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("PostgresAPI.Models.RestaurantType", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("PostgresAPI.Models.Role", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
