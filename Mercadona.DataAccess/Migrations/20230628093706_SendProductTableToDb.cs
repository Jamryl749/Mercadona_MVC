using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mercadona.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SendProductTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Desc = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    IsDiscounted = table.Column<bool>(type: "boolean", nullable: false),
                    DiscountValue = table.Column<decimal>(type: "numeric", nullable: true),
                    DiscountPrice = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Desc", "DiscountPrice", "DiscountValue", "ImageUrl", "IsDiscounted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "A pack of 6 juicy and fresh organic red apples.", null, null, "https://example.com/images/red-apples.jpg", false, "Organic Red Apples", 4.99m },
                    { 2, 1, "Crisp and fresh romaine lettuce, perfect for salads.", null, null, "https://example.com/images/romaine-lettuce.jpg", false, "Romaine Lettuce", 1.49m },
                    { 3, 1, "A 1-pound bag of sweet and crunchy organic carrots.", null, null, "https://example.com/images/carrots.jpg", false, "Organic Carrots", 1.99m },
                    { 4, 1, "A pack of 4 fresh and sweet corn on the cob.", null, null, "https://example.com/images/sweet-corn.jpg", false, "Sweet Corn", 2.49m },
                    { 5, 1, "A 1-pound bag of fresh and nutritious organic broccoli.", null, null, "https://example.com/images/broccoli.jpg", false, "Organic Broccoli", 2.99m },
                    { 6, 1, "A 1-pound bag of sweet and juicy seedless red grapes.", null, null, "https://example.com/images/red-grapes.jpg", false, "Seedless Red Grapes", 3.49m },
                    { 7, 2, "A 1.5-pound package of fresh, boneless, and skinless chicken breasts.", null, null, "https://example.com/images/chicken-breasts.jpg", false, "Boneless Skinless Chicken Breasts", 6.99m },
                    { 8, 2, "A 1-pound package of 85% lean ground beef, perfect for burgers and meatloaf.", null, null, "https://example.com/images/ground-beef.jpg", false, "Ground Beef", 4.49m },
                    { 9, 2, "A 1.25-pound package of bone-in center-cut pork chops.", null, null, "https://example.com/images/pork-chops.jpg", false, "Pork Chops", 5.99m },
                    { 10, 2, "A 12-ounce USDA choice New York strip steak, perfect for grilling.", null, null, "https://example.com/images/new-york-strip-steak.jpg", false, "New York Strip Steak", 9.99m },
                    { 11, 2, "A 4-pound whole chicken, ideal for roasting or grilling.", null, null, "https://example.com/images/whole-chicken.jpg", false, "Whole Chicken", 8.49m },
                    { 12, 2, "A 1-pound package of lean and flavorful turkey sausage links.", null, null, "https://example.com/images/turkey-sausage.jpg", false, "Turkey Sausage", 4.29m },
                    { 13, 3, "A pack of 2 fresh Atlantic salmon fillets, rich in Omega-3.", null, null, "https://example.com/images/salmon-fillets.jpg", false, "Atlantic Salmon Fillets", 11.99m },
                    { 14, 3, "A 1-pound bag of cooked and peeled shrimp, ready to eat.", null, null, "https://example.com/images/cooked-shrimp.jpg", false, "Cooked Shrimp", 12.99m },
                    { 15, 3, "A dozen fresh and succulent oysters, perfect for a seafood feast.", null, null, "https://example.com/images/oysters.jpg", false, "Fresh Oysters", 14.99m },
                    { 16, 3, "A pack of 2 fresh cod fillets, great for fish and chips.", null, null, "https://example.com/images/cod-fillets.jpg", false, "Cod Fillets", 9.99m },
                    { 17, 3, "A live and fresh Atlantic lobster, perfect for a special meal.", null, null, "https://example.com/images/live-lobster.jpg", false, "Live Lobster", 19.99m },
                    { 18, 3, "A 1-pound block of sushi-grade tuna, perfect for sushi or sashimi.", null, null, "https://example.com/images/sushi-tuna.jpg", false, "Sushi Grade Tuna", 16.99m },
                    { 19, 4, "A dozen large, cage-free brown eggs.", null, null, "https://example.com/images/brown-eggs.jpg", false, "Large Brown Eggs", 2.99m },
                    { 20, 4, "A 1-gallon jug of fresh and creamy whole milk.", null, null, "https://example.com/images/whole-milk.jpg", false, "Whole Milk", 3.49m },
                    { 21, 4, "A 1-pound package of unsalted butter.", null, null, "https://example.com/images/unsalted-butter.jpg", false, "Unsalted Butter", 4.49m },
                    { 22, 4, "A 1-pound block of sharp cheddar cheese.", null, null, "https://example.com/images/cheddar-cheese.jpg", false, "Sharp Cheddar Cheese", 5.99m },
                    { 23, 4, "A 32-ounce container of plain, non-fat Greek yogurt.", null, null, "https://example.com/images/greek-yogurt.jpg", false, "Greek Yogurt", 4.99m },
                    { 24, 4, "A 1-pint carton of heavy whipping cream.", null, null, "https://example.com/images/heavy-cream.jpg", false, "Heavy Cream", 2.99m },
                    { 25, 5, "A 10-ounce bag of crispy and delicious classic potato chips.", null, null, "https://example.com/images/potato-chips.jpg", false, "Classic Potato Chips", 3.49m },
                    { 26, 5, "A 3.5-ounce bar of rich and smooth dark chocolate.", null, null, "https://example.com/images/dark-chocolate.jpg", false, "Dark Chocolate Bar", 2.99m },
                    { 27, 5, "A 1-pound bag of soft and chewy assorted gummy bears.", null, null, "https://example.com/images/gummy-bears.jpg", false, "Gummy Bears", 3.99m },
                    { 28, 5, "A 16-ounce jar of crunchy and salted peanuts.", null, null, "https://example.com/images/salted-peanuts.jpg", false, "Salted Peanuts", 4.29m },
                    { 29, 5, "A 7-ounce bag of air-popped popcorn coated in white cheddar.", null, null, "https://example.com/images/white-cheddar-popcorn.jpg", false, "White Cheddar Popcorn", 3.79m },
                    { 30, 5, "A 12-ounce bag of crunchy and salty pretzel sticks.", null, null, "https://example.com/images/pretzel-sticks.jpg", false, "Pretzel Sticks", 2.99m },
                    { 31, 6, "A 1-pound loaf of freshly baked sourdough bread.", null, null, "https://example.com/images/sourdough-bread.jpg", false, "Sourdough Bread", 3.99m },
                    { 32, 6, "A pack of 12 soft and chewy chocolate chip cookies.", null, null, "https://example.com/images/chocolate-chip-cookies.jpg", false, "Chocolate Chip Cookies", 4.49m },
                    { 33, 6, "A pack of 4 delicious and moist blueberry muffins.", null, null, "https://example.com/images/blueberry-muffins.jpg", false, "Blueberry Muffins", 3.99m },
                    { 34, 6, "A freshly baked and crusty French baguette.", null, null, "https://example.com/images/french-baguette.jpg", false, "French Baguette", 2.49m },
                    { 35, 6, "A pack of 6 freshly baked cinnamon rolls with icing.", null, null, "https://example.com/images/cinnamon-rolls.jpg", false, "Cinnamon Rolls", 5.99m },
                    { 36, 6, "A 1-pound loaf of freshly baked whole wheat bread.", null, null, "https://example.com/images/whole-wheat-bread.jpg", false, "Whole Wheat Bread", 3.49m },
                    { 37, 7, "A 64-ounce bottle of 100% freshly squeezed orange juice.", null, null, "https://example.com/images/orange-juice.jpg", false, "Orange Juice", 4.49m },
                    { 38, 7, "A pack of 24 16.9-ounce bottles of purified water.", null, null, "https://example.com/images/bottled-water.jpg", false, "Bottled Water", 3.99m },
                    { 39, 7, "A box of 20 green tea bags, perfect for a healthy and refreshing drink.", null, null, "https://example.com/images/green-tea.jpg", false, "Green Tea", 3.49m },
                    { 40, 7, "A pack of 12 12-ounce cans of refreshing cola soda.", null, null, "https://example.com/images/cola-soda.jpg", false, "Cola Soda", 4.99m },
                    { 41, 7, "A pack of 8 20-ounce bottles of electrolyte-enhanced sports drink.", null, null, "https://example.com/images/sports-drink.jpg", false, "Sports Drink", 6.49m },
                    { 42, 7, "A 64-ounce carton of unsweetened almond milk.", null, null, "https://example.com/images/almond-milk.jpg", false, "Almond Milk", 3.79m },
                    { 43, 8, "A pack of 12 double rolls of soft and strong 2-ply toilet paper.", null, null, "https://example.com/images/toilet-paper.jpg", false, "Toilet Paper", 6.99m },
                    { 44, 8, "A pack of 6 big rolls of absorbent and durable paper towels.", null, null, "https://example.com/images/paper-towels.jpg", false, "Paper Towels", 5.49m },
                    { 45, 8, "A 32-ounce bottle of all-purpose cleaner, suitable for various surfaces.", null, null, "https://example.com/images/all-purpose-cleaner.jpg", false, "All-Purpose Cleaner", 2.99m },
                    { 46, 8, "A 100-ounce bottle of liquid laundry detergent, enough for 64 loads.", null, null, "https://example.com/images/laundry-detergent.jpg", false, "Laundry Detergent", 9.99m },
                    { 47, 8, "A 24-ounce bottle of dishwashing liquid, tough on grease and gentle on hands.", null, null, "https://example.com/images/dishwashing-liquid.jpg", false, "Dishwashing Liquid", 2.79m },
                    { 48, 8, "A pack of 40 13-gallon tall kitchen drawstring garbage bags.", null, null, "https://example.com/images/garbage-bags.jpg", false, "Garbage Bags", 7.49m },
                    { 49, 9, "A 4.7-ounce tube of fluoride toothpaste for cavity protection.", null, null, "https://example.com/images/toothpaste.jpg", false, "Toothpaste", 3.49m },
                    { 50, 9, "A 12-ounce bottle of moisturizing shampoo for all hair types.", null, null, "https://example.com/images/shampoo.jpg", false, "Shampoo", 4.99m },
                    { 51, 9, "An 18-ounce bottle of nourishing body wash for soft and smooth skin.", null, null, "https://example.com/images/body-wash.jpg", false, "Body Wash", 5.49m },
                    { 52, 9, "A 2.7-ounce stick of antiperspirant deodorant for 24-hour protection.", null, null, "https://example.com/images/deodorant.jpg", false, "Deodorant", 3.99m },
                    { 53, 9, "A box of 120 2-ply facial tissues, soft and gentle on the skin.", null, null, "https://example.com/images/facial-tissues.jpg", false, "Facial Tissues", 2.29m },
                    { 54, 9, "An 8-ounce bottle of hand sanitizer, kills 99.9% of germs.", null, null, "https://example.com/images/hand-sanitizer.jpg", false, "Hand Sanitizer", 3.79m },
                    { 55, 10, "A bottle of 100 200mg ibuprofen tablets for pain relief.", null, null, "https://example.com/images/ibuprofen.jpg", false, "Ibuprofen", 7.99m },
                    { 56, 10, "A bottle of 60 daily multivitamin tablets for overall health.", null, null, "https://example.com/images/multivitamins.jpg", false, "Multivitamins", 9.49m },
                    { 57, 10, "A box of 30 non-drowsy allergy relief tablets.", null, null, "https://example.com/images/allergy-relief.jpg", false, "Allergy Relief", 6.99m },
                    { 58, 10, "A 4-ounce bottle of cough suppressant syrup for cold and flu relief.", null, null, "https://example.com/images/cough-suppressant.jpg", false, "Cough Suppressant", 5.49m },
                    { 59, 10, "A box of 100 assorted sizes adhesive bandages for wound protection.", null, null, "https://example.com/images/band-aids.jpg", false, "Band-Aids", 4.29m },
                    { 60, 10, "A bottle of 100 500mg extra strength acetaminophen caplets for pain and fever relief.", null, null, "https://example.com/images/acetaminophen.jpg", false, "Acetaminophen", 7.49m },
                    { 61, 11, "A powerful 700-watt countertop blender with a 40-ounce glass jar.", null, null, "https://example.com/images/blender.jpg", false, "Blender", 49.99m },
                    { 62, 11, "A 1000-watt countertop microwave oven with a 1.1 cubic feet capacity.", null, null, "https://example.com/images/microwave-oven.jpg", false, "Microwave Oven", 89.99m },
                    { 63, 11, "A 2-slice toaster with 7 browning settings and a bagel function.", null, null, "https://example.com/images/toaster.jpg", false, "Toaster", 29.99m },
                    { 64, 11, "A 6-quart programmable slow cooker with a digital timer and removable stoneware.", null, null, "https://example.com/images/slow-cooker.jpg", false, "Slow Cooker", 59.99m },
                    { 65, 11, "A 1.7-liter stainless steel electric kettle with auto shut-off and boil-dry protection.", null, null, "https://example.com/images/electric-kettle.jpg", false, "Electric Kettle", 39.99m },
                    { 66, 11, "A HEPA-filter air purifier with 3 fan speeds for rooms up to 300 sq. ft.", null, null, "https://example.com/images/air-purifier.jpg", false, "Air Purifier", 99.99m },
                    { 67, 12, "A 20V cordless drill with a 2-speed gearbox and a 3/8-inch keyless chuck.", null, null, "https://example.com/images/cordless-drill.jpg", false, "Cordless Drill", 59.99m },
                    { 68, 12, "A 9-piece paint roller set including a tray, roller frame, and various roller covers.", null, null, "https://example.com/images/paint-roller-set.jpg", false, "Paint Roller Set", 14.99m },
                    { 69, 12, "A 16-ounce claw hammer with a fiberglass handle for durability and comfort.", null, null, "https://example.com/images/hammer.jpg", false, "Hammer", 12.99m },
                    { 70, 12, "A 25-foot retractable tape measure with a durable, impact-resistant case.", null, null, "https://example.com/images/tape-measure.jpg", false, "Tape Measure", 9.99m },
                    { 71, 12, "A 10-piece screwdriver set, including various flathead and Phillips sizes.", null, null, "https://example.com/images/screwdriver-set.jpg", false, "Screwdriver Set", 19.99m },
                    { 72, 12, "A retractable utility knife with a comfortable grip and quick blade change.", null, null, "https://example.com/images/utility-knife.jpg", false, "Utility Knife", 6.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
