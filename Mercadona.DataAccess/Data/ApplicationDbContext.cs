using Mercadona.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Namespace for Mercadona DataAccess Data.
/// </summary>
namespace Mercadona.DataAccess.Data
{
    /// <summary>
    /// Initializes a new instance of the ApplicationDbContext class.
    /// </summary>
    /// <param name="options">The options to be used by a DbContext.</param>
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the discounts.
        /// </summary>
        public DbSet<Discount> Discounts { get; set; }

        /// <summary>
        /// Configures the model that was discovered by convention from the entity types
        /// exposed in DbSet properties on your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific to a given database.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Category, Product, and Discount entities
            #region Category Seeds
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Fresh Produce"
                },
                new Category
                {
                    Id = 2,
                    Name = "Meat and Poultry"
                },
                new Category
                {
                    Id = 3,
                    Name = "Seafood"
                },
                new Category
                {
                    Id = 4,
                    Name = "Dairy and Eggs"
                },
                new Category
                {
                    Id = 5,
                    Name = "Snacks and Confectionery"
                },
                new Category
                {
                    Id = 6,
                    Name = "Bakery"
                },
                new Category
                {
                    Id = 7,
                    Name = "Beverages"
                },
                new Category
                {
                    Id = 8,
                    Name = "Household Essential"
                },
                new Category
                {
                    Id = 9,
                    Name = "Personal Care"
                },
                new Category
                {
                    Id = 10,
                    Name = "Pharmacy"
                },
                new Category
                {
                    Id = 11,
                    Name = "Home Appliance"
                },
                new Category
                {
                    Id = 12,
                    Name = "DIY"
                }
                );
            #endregion
            #region Product Seeds
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Organic Red Apples",
                    Desc = "A pack of 6 juicy and fresh organic red apples.",
                    ImageUrl = "https://example.com/images/red-apples.jpg",
                    Price = 4.99m,
                    CategoryId = 1,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 2,
                    Name = "Romaine Lettuce",
                    Desc = "Crisp and fresh romaine lettuce, perfect for salads.",
                    ImageUrl = "https://example.com/images/romaine-lettuce.jpg",
                    Price = 1.49m,
                    CategoryId = 1,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 3,
                    Name = "Organic Carrots",
                    Desc = "A 1-pound bag of sweet and crunchy organic carrots.",
                    ImageUrl = "https://example.com/images/carrots.jpg",
                    Price = 1.99m,
                    CategoryId = 1,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 4,
                    Name = "Sweet Corn",
                    Desc = "A pack of 4 fresh and sweet corn on the cob.",
                    ImageUrl = "https://example.com/images/sweet-corn.jpg",
                    Price = 2.49m,
                    CategoryId = 1,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 5,
                    Name = "Organic Broccoli",
                    Desc = "A 1-pound bag of fresh and nutritious organic broccoli.",
                    ImageUrl = "https://example.com/images/broccoli.jpg",
                    Price = 2.99m,
                    CategoryId = 1,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 6,
                    Name = "Seedless Red Grapes",
                    Desc = "A 1-pound bag of sweet and juicy seedless red grapes.",
                    ImageUrl = "https://example.com/images/red-grapes.jpg",
                    Price = 3.49m,
                    CategoryId = 1,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 7,
                    Name = "Chicken Breasts",
                    Desc = "A 1.5-pound package of fresh, boneless, and skinless chicken breasts.",
                    ImageUrl = "https://example.com/images/chicken-breasts.jpg",
                    Price = 6.99m,
                    CategoryId = 2,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 8,
                    Name = "Ground Beef",
                    Desc = "A 1-pound package of 85% lean ground beef, perfect for burgers and meatloaf.",
                    ImageUrl = "https://example.com/images/ground-beef.jpg",
                    Price = 4.49m,
                    CategoryId = 2,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 9,
                    Name = "Pork Chops",
                    Desc = "A 1.25-pound package of bone-in center-cut pork chops.",
                    ImageUrl = "https://example.com/images/pork-chops.jpg",
                    Price = 5.99m,
                    CategoryId = 2,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 10,
                    Name = "New York Strip Steak",
                    Desc = "A 12-ounce USDA choice New York strip steak, perfect for grilling.",
                    ImageUrl = "https://example.com/images/new-york-strip-steak.jpg",
                    Price = 9.99m,
                    CategoryId = 2,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 11,
                    Name = "Whole Chicken",
                    Desc = "A 4-pound whole chicken, ideal for roasting or grilling.",
                    ImageUrl = "https://example.com/images/whole-chicken.jpg",
                    Price = 8.49m,
                    CategoryId = 2,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 12,
                    Name = "Turkey Sausage",
                    Desc = "A 1-pound package of lean and flavorful turkey sausage links.",
                    ImageUrl = "https://example.com/images/turkey-sausage.jpg",
                    Price = 4.29m,
                    CategoryId = 2,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 13,
                    Name = "Atlantic Salmon Fillets",
                    Desc = "A pack of 2 fresh Atlantic salmon fillets, rich in Omega-3.",
                    ImageUrl = "https://example.com/images/salmon-fillets.jpg",
                    Price = 11.99m,
                    CategoryId = 3,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 14,
                    Name = "Cooked Shrimp",
                    Desc = "A 1-pound bag of cooked and peeled shrimp, ready to eat.",
                    ImageUrl = "https://example.com/images/cooked-shrimp.jpg",
                    Price = 12.99m,
                    CategoryId = 3,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 15,
                    Name = "Fresh Oysters",
                    Desc = "A dozen fresh and succulent oysters, perfect for a seafood feast.",
                    ImageUrl = "https://example.com/images/oysters.jpg",
                    Price = 14.99m,
                    CategoryId = 3,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 16,
                    Name = "Cod Fillets",
                    Desc = "A pack of 2 fresh cod fillets, great for fish and chips.",
                    ImageUrl = "https://example.com/images/cod-fillets.jpg",
                    Price = 9.99m,
                    CategoryId = 3,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 17,
                    Name = "Live Lobster",
                    Desc = "A live and fresh Atlantic lobster, perfect for a special meal.",
                    ImageUrl = "https://example.com/images/live-lobster.jpg",
                    Price = 19.99m,
                    CategoryId = 3,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 18,
                    Name = "Sushi Grade Tuna",
                    Desc = "A 1-pound block of sushi-grade tuna, perfect for sushi or sashimi.",
                    ImageUrl = "https://example.com/images/sushi-tuna.jpg",
                    Price = 16.99m,
                    CategoryId = 3,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 19,
                    Name = "Large Brown Eggs",
                    Desc = "A dozen large, cage-free brown eggs.",
                    ImageUrl = "https://example.com/images/brown-eggs.jpg",
                    Price = 2.99m,
                    CategoryId = 4,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 20,
                    Name = "Whole Milk",
                    Desc = "A 1-gallon jug of fresh and creamy whole milk.",
                    ImageUrl = "https://example.com/images/whole-milk.jpg",
                    Price = 3.49m,
                    CategoryId = 4,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 21,
                    Name = "Unsalted Butter",
                    Desc = "A 1-pound package of unsalted butter.",
                    ImageUrl = "https://example.com/images/unsalted-butter.jpg",
                    Price = 4.49m,
                    CategoryId = 4,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 22,
                    Name = "Sharp Cheddar Cheese",
                    Desc = "A 1-pound block of sharp cheddar cheese.",
                    ImageUrl = "https://example.com/images/cheddar-cheese.jpg",
                    Price = 5.99m,
                    CategoryId = 4,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 23,
                    Name = "Greek Yogurt",
                    Desc = "A 32-ounce container of plain, non-fat Greek yogurt.",
                    ImageUrl = "https://example.com/images/greek-yogurt.jpg",
                    Price = 4.99m,
                    CategoryId = 4,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 24,
                    Name = "Heavy Cream",
                    Desc = "A 1-pint carton of heavy whipping cream.",
                    ImageUrl = "https://example.com/images/heavy-cream.jpg",
                    Price = 2.99m,
                    CategoryId = 4,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 25,
                    Name = "Classic Potato Chips",
                    Desc = "A 10-ounce bag of crispy and delicious classic potato chips.",
                    ImageUrl = "https://example.com/images/potato-chips.jpg",
                    Price = 3.49m,
                    CategoryId = 5,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 26,
                    Name = "Dark Chocolate Bar",
                    Desc = "A 3.5-ounce bar of rich and smooth dark chocolate.",
                    ImageUrl = "https://example.com/images/dark-chocolate.jpg",
                    Price = 2.99m,
                    CategoryId = 5,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 27,
                    Name = "Gummy Bears",
                    Desc = "A 1-pound bag of soft and chewy assorted gummy bears.",
                    ImageUrl = "https://example.com/images/gummy-bears.jpg",
                    Price = 3.99m,
                    CategoryId = 5,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 28,
                    Name = "Salted Peanuts",
                    Desc = "A 16-ounce jar of crunchy and salted peanuts.",
                    ImageUrl = "https://example.com/images/salted-peanuts.jpg",
                    Price = 4.29m,
                    CategoryId = 5,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 29,
                    Name = "White Cheddar Popcorn",
                    Desc = "A 7-ounce bag of air-popped popcorn coated in white cheddar.",
                    ImageUrl = "https://example.com/images/white-cheddar-popcorn.jpg",
                    Price = 3.79m,
                    CategoryId = 5,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 30,
                    Name = "Pretzel Sticks",
                    Desc = "A 12-ounce bag of crunchy and salty pretzel sticks.",
                    ImageUrl = "https://example.com/images/pretzel-sticks.jpg",
                    Price = 2.99m,
                    CategoryId = 5,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 31,
                    Name = "Sourdough Bread",
                    Desc = "A 1-pound loaf of freshly baked sourdough bread.",
                    ImageUrl = "https://example.com/images/sourdough-bread.jpg",
                    Price = 3.99m,
                    CategoryId = 6,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 32,
                    Name = "Chocolate Chip Cookies",
                    Desc = "A pack of 12 soft and chewy chocolate chip cookies.",
                    ImageUrl = "https://example.com/images/chocolate-chip-cookies.jpg",
                    Price = 4.49m,
                    CategoryId = 6,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 33,
                    Name = "Blueberry Muffins",
                    Desc = "A pack of 4 delicious and moist blueberry muffins.",
                    ImageUrl = "https://example.com/images/blueberry-muffins.jpg",
                    Price = 3.99m,
                    CategoryId = 6,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 34,
                    Name = "French Baguette",
                    Desc = "A freshly baked and crusty French baguette.",
                    ImageUrl = "https://example.com/images/french-baguette.jpg",
                    Price = 2.49m,
                    CategoryId = 6,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 35,
                    Name = "Cinnamon Rolls",
                    Desc = "A pack of 6 freshly baked cinnamon rolls with icing.",
                    ImageUrl = "https://example.com/images/cinnamon-rolls.jpg",
                    Price = 5.99m,
                    CategoryId = 6,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 36,
                    Name = "Whole Wheat Bread",
                    Desc = "A 1-pound loaf of freshly baked whole wheat bread.",
                    ImageUrl = "https://example.com/images/whole-wheat-bread.jpg",
                    Price = 3.49m,
                    CategoryId = 6,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 37,
                    Name = "Orange Juice",
                    Desc = "A 64-ounce bottle of 100% freshly squeezed orange juice.",
                    ImageUrl = "https://example.com/images/orange-juice.jpg",
                    Price = 4.49m,
                    CategoryId = 7,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 38,
                    Name = "Bottled Water",
                    Desc = "A pack of 24 16.9-ounce bottles of purified water.",
                    ImageUrl = "https://example.com/images/bottled-water.jpg",
                    Price = 3.99m,
                    CategoryId = 7,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 39,
                    Name = "Green Tea",
                    Desc = "A box of 20 green tea bags, perfect for a healthy and refreshing drink.",
                    ImageUrl = "https://example.com/images/green-tea.jpg",
                    Price = 3.49m,
                    CategoryId = 7,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 40,
                    Name = "Cola Soda",
                    Desc = "A pack of 12 12-ounce cans of refreshing cola soda.",
                    ImageUrl = "https://example.com/images/cola-soda.jpg",
                    Price = 4.99m,
                    CategoryId = 7,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 41,
                    Name = "Sports Drink",
                    Desc = "A pack of 8 20-ounce bottles of electrolyte-enhanced sports drink.",
                    ImageUrl = "https://example.com/images/sports-drink.jpg",
                    Price = 6.49m,
                    CategoryId = 7,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 42,
                    Name = "Almond Milk",
                    Desc = "A 64-ounce carton of unsweetened almond milk.",
                    ImageUrl = "https://example.com/images/almond-milk.jpg",
                    Price = 3.79m,
                    CategoryId = 7,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 43,
                    Name = "Toilet Paper",
                    Desc = "A pack of 12 double rolls of soft and strong 2-ply toilet paper.",
                    ImageUrl = "https://example.com/images/toilet-paper.jpg",
                    Price = 6.99m,
                    CategoryId = 8,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 44,
                    Name = "Paper Towels",
                    Desc = "A pack of 6 big rolls of absorbent and durable paper towels.",
                    ImageUrl = "https://example.com/images/paper-towels.jpg",
                    Price = 5.49m,
                    CategoryId = 8,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 45,
                    Name = "All-Purpose Cleaner",
                    Desc = "A 32-ounce bottle of all-purpose cleaner, suitable for various surfaces.",
                    ImageUrl = "https://example.com/images/all-purpose-cleaner.jpg",
                    Price = 2.99m,
                    CategoryId = 8,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 46,
                    Name = "Laundry Detergent",
                    Desc = "A 100-ounce bottle of liquid laundry detergent, enough for 64 loads.",
                    ImageUrl = "https://example.com/images/laundry-detergent.jpg",
                    Price = 9.99m,
                    CategoryId = 8,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 47,
                    Name = "Dishwashing Liquid",
                    Desc = "A 24-ounce bottle of dishwashing liquid, tough on grease and gentle on hands.",
                    ImageUrl = "https://example.com/images/dishwashing-liquid.jpg",
                    Price = 2.79m,
                    CategoryId = 8,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 48,
                    Name = "Garbage Bags",
                    Desc = "A pack of 40 13-gallon tall kitchen drawstring garbage bags.",
                    ImageUrl = "https://example.com/images/garbage-bags.jpg",
                    Price = 7.49m,
                    CategoryId = 8,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 49,
                    Name = "Toothpaste",
                    Desc = "A 4.7-ounce tube of fluoride toothpaste for cavity protection.",
                    ImageUrl = "https://example.com/images/toothpaste.jpg",
                    Price = 3.49m,
                    CategoryId = 9,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 50,
                    Name = "Shampoo",
                    Desc = "A 12-ounce bottle of moisturizing shampoo for all hair types.",
                    ImageUrl = "https://example.com/images/shampoo.jpg",
                    Price = 4.99m,
                    CategoryId = 9,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 51,
                    Name = "Body Wash",
                    Desc = "An 18-ounce bottle of nourishing body wash for soft and smooth skin.",
                    ImageUrl = "https://example.com/images/body-wash.jpg",
                    Price = 5.49m,
                    CategoryId = 9,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 52,
                    Name = "Deodorant",
                    Desc = "A 2.7-ounce stick of antiperspirant deodorant for 24-hour protection.",
                    ImageUrl = "https://example.com/images/deodorant.jpg",
                    Price = 3.99m,
                    CategoryId = 9,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 53,
                    Name = "Facial Tissues",
                    Desc = "A box of 120 2-ply facial tissues, soft and gentle on the skin.",
                    ImageUrl = "https://example.com/images/facial-tissues.jpg",
                    Price = 2.29m,
                    CategoryId = 9,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 54,
                    Name = "Hand Sanitizer",
                    Desc = "An 8-ounce bottle of hand sanitizer, kills 99.9% of germs.",
                    ImageUrl = "https://example.com/images/hand-sanitizer.jpg",
                    Price = 3.79m,
                    CategoryId = 9,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 55,
                    Name = "Ibuprofen",
                    Desc = "A bottle of 100 200mg ibuprofen tablets for pain relief.",
                    ImageUrl = "https://example.com/images/ibuprofen.jpg",
                    Price = 7.99m,
                    CategoryId = 10,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 56,
                    Name = "Multivitamins",
                    Desc = "A bottle of 60 daily multivitamin tablets for overall health.",
                    ImageUrl = "https://example.com/images/multivitamins.jpg",
                    Price = 9.49m,
                    CategoryId = 10,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 57,
                    Name = "Allergy Relief",
                    Desc = "A box of 30 non-drowsy allergy relief tablets.",
                    ImageUrl = "https://example.com/images/allergy-relief.jpg",
                    Price = 6.99m,
                    CategoryId = 10,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 58,
                    Name = "Cough Suppressant",
                    Desc = "A 4-ounce bottle of cough suppressant syrup for cold and flu relief.",
                    ImageUrl = "https://example.com/images/cough-suppressant.jpg",
                    Price = 5.49m,
                    CategoryId = 10,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 59,
                    Name = "Band-Aids",
                    Desc = "A box of 100 assorted sizes adhesive bandages for wound protection.",
                    ImageUrl = "https://example.com/images/band-aids.jpg",
                    Price = 4.29m,
                    CategoryId = 10,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 60,
                    Name = "Acetaminophen",
                    Desc = "A bottle of 100 500mg extra strength acetaminophen caplets for pain and fever relief.",
                    ImageUrl = "https://example.com/images/acetaminophen.jpg",
                    Price = 7.49m,
                    CategoryId = 10,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 61,
                    Name = "Blender",
                    Desc = "A powerful 700-watt countertop blender with a 40-ounce glass jar.",
                    ImageUrl = "https://example.com/images/blender.jpg",
                    Price = 49.99m,
                    CategoryId = 11,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 62,
                    Name = "Microwave Oven",
                    Desc = "A 1000-watt countertop microwave oven with a 1.1 cubic feet capacity.",
                    ImageUrl = "https://example.com/images/microwave-oven.jpg",
                    Price = 89.99m,
                    CategoryId = 11,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 63,
                    Name = "Toaster",
                    Desc = "A 2-slice toaster with 7 browning settings and a bagel function.",
                    ImageUrl = "https://example.com/images/toaster.jpg",
                    Price = 29.99m,
                    CategoryId = 11,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 64,
                    Name = "Slow Cooker",
                    Desc = "A 6-quart programmable slow cooker with a digital timer and removable stoneware.",
                    ImageUrl = "https://example.com/images/slow-cooker.jpg",
                    Price = 59.99m,
                    CategoryId = 11,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 65,
                    Name = "Electric Kettle",
                    Desc = "A 1.7-liter stainless steel electric kettle with auto shut-off and boil-dry protection.",
                    ImageUrl = "https://example.com/images/electric-kettle.jpg",
                    Price = 39.99m,
                    CategoryId = 11,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 66,
                    Name = "Air Purifier",
                    Desc = "A HEPA-filter air purifier with 3 fan speeds for rooms up to 300 sq. ft.",
                    ImageUrl = "https://example.com/images/air-purifier.jpg",
                    Price = 99.99m,
                    CategoryId = 11,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 67,
                    Name = "Cordless Drill",
                    Desc = "A 20V cordless drill with a 2-speed gearbox and a 3/8-inch keyless chuck.",
                    ImageUrl = "https://example.com/images/cordless-drill.jpg",
                    Price = 59.99m,
                    CategoryId = 12,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 68,
                    Name = "Paint Roller Set",
                    Desc = "A 9-piece paint roller set including a tray, roller frame, and various roller covers.",
                    ImageUrl = "https://example.com/images/paint-roller-set.jpg",
                    Price = 14.99m,
                    CategoryId = 12,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 69,
                    Name = "Hammer",
                    Desc = "A 16-ounce claw hammer with a fiberglass handle for durability and comfort.",
                    ImageUrl = "https://example.com/images/hammer.jpg",
                    Price = 12.99m,
                    CategoryId = 12,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 70,
                    Name = "Tape Measure",
                    Desc = "A 25-foot retractable tape measure with a durable, impact-resistant case.",
                    ImageUrl = "https://example.com/images/tape-measure.jpg",
                    Price = 9.99m,
                    CategoryId = 12,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 71,
                    Name = "Screwdriver Set",
                    Desc = "A 10-piece screwdriver set, including various flathead and Phillips sizes.",
                    ImageUrl = "https://example.com/images/screwdriver-set.jpg",
                    Price = 19.99m,
                    CategoryId = 12,
                    DiscountId = null,
                    DiscountedPrice = 0m
                },
                new Product
                {
                    Id = 72,
                    Name = "Utility Knife",
                    Desc = "A retractable utility knife with a comfortable grip and quick blade change.",
                    ImageUrl = "https://example.com/images/utility-knife.jpg",
                    Price = 6.99m,
                    CategoryId = 12,
                    DiscountId = null,
                    DiscountedPrice = 0m
                }
                ); ;
            #endregion
            #region Discount Seeds
            modelBuilder.Entity<Discount>().HasData(
                new Discount
                {
                    Id = 1,
                    Name = "Christmas Discount",
                    DiscountValue = 25,
                    StartDate = new DateTime(2023, 12, 20),
                    EndDate = new DateTime(2023, 12, 26),
                },
                new Discount
                {
                    Id = 2,
                    Name = "Winter Discount",
                    DiscountValue = 15,
                    StartDate = new DateTime(2023, 12, 1),
                    EndDate = new DateTime(2024, 3, 1),
                },
                new Discount
                {
                    Id = 3,
                    Name = "DIY Discount",
                    DiscountValue = 10,
                    StartDate = new DateTime(2023, 6, 30),
                    EndDate = new DateTime(2023, 11, 30),
                },
                new Discount
                {
                    Id = 4,
                    Name = "Summer Discount",
                    DiscountValue = 10,
                    StartDate = new DateTime(2023, 7, 1),
                    EndDate = new DateTime(2023, 8, 31),
                }
                );
            #endregion
        }
    }
}
