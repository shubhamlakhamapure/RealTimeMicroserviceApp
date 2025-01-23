using Microsoft.EntityFrameworkCore;
using Product.API.Entities;

namespace Product.API.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        public DbSet<Product.API.Entities.Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category {iCategory = 1, Title="Camera" },
                new Category {iCategory = 2, Title="Books" }
                
                );

            modelBuilder.Entity<Product.API.Entities.Product>().HasData(
                new Entities.Product { iProduct = 1, Title= "Canon EOS 1500D DSLR",
                    ImageUrl= "https://www.flipkart.com/canon-eos-1500d-dslr-camera-body-18-55-mm-ii-lens/p/itm033175ceb4ddd?pid=DLLFAEWE22ZAERXG&lid=LSTDLLFAEWE22ZAERXGWRV3XA&marketplace=FLIPKART&store=jek%2Fp31%2Ftrv&srno=b_1_1&otracker=browse&fm=organic&iid=en_GcT4RQGZ2GejFulXVnwvqd5HYbIix55KxwbNMLcyqaCAkIzI6BjC0lN3VnK27TDTzv48STZxkRBQO4Bbp5YpfPUFjCTyOHoHZs-Z5_PS_w0%3D&ppt=None&ppn=None&ssid=fbjhgo09kg0000001737262932517"
               ,
                    Description = "Canon EOS 1500D DSLR Camera Body+ 18-55 mm IS II Lens  (Black)",
                    CategoryId = 1,
                    Price =36900
                },
                 new Entities.Product
                 {
                     iProduct = 2,
                     Title = "NIKON D7500 DSLR",
                     ImageUrl = "https://www.flipkart.com/nikon-d7500-dslr-camera-body-18-140-mm-lens/p/itme57c2bb8a03cd?pid=DLLFCKK6GET9EEDC&lid=LSTDLLFCKK6GET9EEDCJAOQAJ&marketplace=FLIPKART&store=jek%2Fp31%2Ftrv&spotlightTagId=FkPickId_jek%2Fp31%2Ftrv&srno=b_1_4&otracker=browse&fm=organic&iid=881bd602-89c8-4279-ade9-09118d067fb3.DLLFCKK6GET9EEDC.SEARCH&ppt=browse&ppn=browse"
               ,
                     Description = "NIKON D7500 DSLR Camera Body with 18-140 mm Lens (Black)",
                     CategoryId = 1,
                     Price = 69999
                 },
                 new Entities.Product
                 {
                     iProduct = 3,
                     Title = "Land of Terror",
                     ImageUrl = "https://covers.openlibrary.org/b/id/14487114-L.jpg"
               ,
                     Description = "EDGAR RICE Land of Terror (Pellucidar No 6)",
                     CategoryId = 2,
                     Price = 599
                 },
                 new Entities.Product
                 {
                     iProduct = 4,
                     Title = "The God Delusion",
                     ImageUrl = "https://covers.openlibrary.org/b/id/8231555-L.jpg"
               ,
                     Description = "The God Delusion First American edition by Richard Dawkins",
                     CategoryId = 2,
                     Price = 799
                 }
              


                );


        }
    }
}
