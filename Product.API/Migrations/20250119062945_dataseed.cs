﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.API.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    iCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.iCategory);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    iProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.iProduct);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "iCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "iCategory", "Title" },
                values: new object[] { 1, "Camera" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "iCategory", "Title" },
                values: new object[] { 2, "Books" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "iProduct", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Canon EOS 1500D DSLR Camera Body+ 18-55 mm IS II Lens  (Black)", "https://www.flipkart.com/canon-eos-1500d-dslr-camera-body-18-55-mm-ii-lens/p/itm033175ceb4ddd?pid=DLLFAEWE22ZAERXG&lid=LSTDLLFAEWE22ZAERXGWRV3XA&marketplace=FLIPKART&store=jek%2Fp31%2Ftrv&srno=b_1_1&otracker=browse&fm=organic&iid=en_GcT4RQGZ2GejFulXVnwvqd5HYbIix55KxwbNMLcyqaCAkIzI6BjC0lN3VnK27TDTzv48STZxkRBQO4Bbp5YpfPUFjCTyOHoHZs-Z5_PS_w0%3D&ppt=None&ppn=None&ssid=fbjhgo09kg0000001737262932517", 36900m, "Canon EOS 1500D DSLR" },
                    { 2, 1, "NIKON D7500 DSLR Camera Body with 18-140 mm Lens (Black)", "https://www.flipkart.com/nikon-d7500-dslr-camera-body-18-140-mm-lens/p/itme57c2bb8a03cd?pid=DLLFCKK6GET9EEDC&lid=LSTDLLFCKK6GET9EEDCJAOQAJ&marketplace=FLIPKART&store=jek%2Fp31%2Ftrv&spotlightTagId=FkPickId_jek%2Fp31%2Ftrv&srno=b_1_4&otracker=browse&fm=organic&iid=881bd602-89c8-4279-ade9-09118d067fb3.DLLFCKK6GET9EEDC.SEARCH&ppt=browse&ppn=browse", 69999m, "NIKON D7500 DSLR" },
                    { 3, 2, "EDGAR RICE Land of Terror (Pellucidar No 6)", "https://covers.openlibrary.org/b/id/14487114-L.jpg", 599m, "Land of Terror" },
                    { 4, 2, "The God Delusion First American edition by Richard Dawkins", "https://covers.openlibrary.org/b/id/8231555-L.jpg", 799m, "The God Delusion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
