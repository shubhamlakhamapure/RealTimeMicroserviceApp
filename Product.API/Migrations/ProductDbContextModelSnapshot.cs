﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.API.Data;

#nullable disable

namespace Product.API.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Product.API.Entities.Category", b =>
                {
                    b.Property<int>("iCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("iCategory"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("iCategory");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            iCategory = 1,
                            Title = "Camera"
                        },
                        new
                        {
                            iCategory = 2,
                            Title = "Books"
                        });
                });

            modelBuilder.Entity("Product.API.Entities.Product", b =>
                {
                    b.Property<int>("iProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("iProduct"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("iProduct");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            iProduct = 1,
                            CategoryId = 1,
                            Description = "Canon EOS 1500D DSLR Camera Body+ 18-55 mm IS II Lens  (Black)",
                            ImageUrl = "https://www.flipkart.com/canon-eos-1500d-dslr-camera-body-18-55-mm-ii-lens/p/itm033175ceb4ddd?pid=DLLFAEWE22ZAERXG&lid=LSTDLLFAEWE22ZAERXGWRV3XA&marketplace=FLIPKART&store=jek%2Fp31%2Ftrv&srno=b_1_1&otracker=browse&fm=organic&iid=en_GcT4RQGZ2GejFulXVnwvqd5HYbIix55KxwbNMLcyqaCAkIzI6BjC0lN3VnK27TDTzv48STZxkRBQO4Bbp5YpfPUFjCTyOHoHZs-Z5_PS_w0%3D&ppt=None&ppn=None&ssid=fbjhgo09kg0000001737262932517",
                            Price = 36900m,
                            Title = "Canon EOS 1500D DSLR"
                        },
                        new
                        {
                            iProduct = 2,
                            CategoryId = 1,
                            Description = "NIKON D7500 DSLR Camera Body with 18-140 mm Lens (Black)",
                            ImageUrl = "https://www.flipkart.com/nikon-d7500-dslr-camera-body-18-140-mm-lens/p/itme57c2bb8a03cd?pid=DLLFCKK6GET9EEDC&lid=LSTDLLFCKK6GET9EEDCJAOQAJ&marketplace=FLIPKART&store=jek%2Fp31%2Ftrv&spotlightTagId=FkPickId_jek%2Fp31%2Ftrv&srno=b_1_4&otracker=browse&fm=organic&iid=881bd602-89c8-4279-ade9-09118d067fb3.DLLFCKK6GET9EEDC.SEARCH&ppt=browse&ppn=browse",
                            Price = 69999m,
                            Title = "NIKON D7500 DSLR"
                        },
                        new
                        {
                            iProduct = 3,
                            CategoryId = 2,
                            Description = "EDGAR RICE Land of Terror (Pellucidar No 6)",
                            ImageUrl = "https://covers.openlibrary.org/b/id/14487114-L.jpg",
                            Price = 599m,
                            Title = "Land of Terror"
                        },
                        new
                        {
                            iProduct = 4,
                            CategoryId = 2,
                            Description = "The God Delusion First American edition by Richard Dawkins",
                            ImageUrl = "https://covers.openlibrary.org/b/id/8231555-L.jpg",
                            Price = 799m,
                            Title = "The God Delusion"
                        });
                });

            modelBuilder.Entity("Product.API.Entities.Product", b =>
                {
                    b.HasOne("Product.API.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}