using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mercadona.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DiscountValue = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Desc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountId = table.Column<int>(type: "integer", nullable: true),
                    DiscountedPrice = table.Column<decimal>(type: "numeric", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Products_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fresh Produce" },
                    { 2, "Meat and Poultry" },
                    { 3, "Seafood" },
                    { 4, "Dairy and Eggs" },
                    { 5, "Snacks and Confectionery" },
                    { 6, "Bakery" },
                    { 7, "Beverages" },
                    { 8, "Household Essential" },
                    { 9, "Personal Care" },
                    { 10, "Pharmacy" },
                    { 11, "Home Appliance" },
                    { 12, "DIY" }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "DiscountValue", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, 25, new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas Discount", new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 15, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Winter Discount", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 10, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "DIY Discount", new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 10, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summer Discount", new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Desc", "DiscountId", "DiscountedPrice", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "A pack of 6 juicy and fresh organic red apples.", null, 0m, "https://example.com/images/red-apples.jpg", "Organic Red Apples", 4.99m },
                    { 2, 1, "Crisp and fresh romaine lettuce, perfect for salads.", null, 0m, "https://example.com/images/romaine-lettuce.jpg", "Romaine Lettuce", 1.49m },
                    { 3, 1, "A 1-pound bag of sweet and crunchy organic carrots.", null, 0m, "https://example.com/images/carrots.jpg", "Organic Carrots", 1.99m },
                    { 4, 1, "A pack of 4 fresh and sweet corn on the cob.", null, 0m, "https://example.com/images/sweet-corn.jpg", "Sweet Corn", 2.49m },
                    { 5, 1, "A 1-pound bag of fresh and nutritious organic broccoli.", null, 0m, "https://example.com/images/broccoli.jpg", "Organic Broccoli", 2.99m },
                    { 6, 1, "A 1-pound bag of sweet and juicy seedless red grapes.", null, 0m, "https://example.com/images/red-grapes.jpg", "Seedless Red Grapes", 3.49m },
                    { 7, 2, "A 1.5-pound package of fresh, boneless, and skinless chicken breasts.", null, 0m, "https://example.com/images/chicken-breasts.jpg", "Chicken Breasts", 6.99m },
                    { 8, 2, "A 1-pound package of 85% lean ground beef, perfect for burgers and meatloaf.", null, 0m, "https://example.com/images/ground-beef.jpg", "Ground Beef", 4.49m },
                    { 9, 2, "A 1.25-pound package of bone-in center-cut pork chops.", null, 0m, "https://example.com/images/pork-chops.jpg", "Pork Chops", 5.99m },
                    { 10, 2, "A 12-ounce USDA choice New York strip steak, perfect for grilling.", null, 0m, "https://example.com/images/new-york-strip-steak.jpg", "New York Strip Steak", 9.99m },
                    { 11, 2, "A 4-pound whole chicken, ideal for roasting or grilling.", null, 0m, "https://example.com/images/whole-chicken.jpg", "Whole Chicken", 8.49m },
                    { 12, 2, "A 1-pound package of lean and flavorful turkey sausage links.", null, 0m, "https://example.com/images/turkey-sausage.jpg", "Turkey Sausage", 4.29m },
                    { 13, 3, "A pack of 2 fresh Atlantic salmon fillets, rich in Omega-3.", null, 0m, "https://example.com/images/salmon-fillets.jpg", "Atlantic Salmon Fillets", 11.99m },
                    { 14, 3, "A 1-pound bag of cooked and peeled shrimp, ready to eat.", null, 0m, "https://example.com/images/cooked-shrimp.jpg", "Cooked Shrimp", 12.99m },
                    { 15, 3, "A dozen fresh and succulent oysters, perfect for a seafood feast.", null, 0m, "https://example.com/images/oysters.jpg", "Fresh Oysters", 14.99m },
                    { 16, 3, "A pack of 2 fresh cod fillets, great for fish and chips.", null, 0m, "https://example.com/images/cod-fillets.jpg", "Cod Fillets", 9.99m },
                    { 17, 3, "A live and fresh Atlantic lobster, perfect for a special meal.", null, 0m, "https://example.com/images/live-lobster.jpg", "Live Lobster", 19.99m },
                    { 18, 3, "A 1-pound block of sushi-grade tuna, perfect for sushi or sashimi.", null, 0m, "https://example.com/images/sushi-tuna.jpg", "Sushi Grade Tuna", 16.99m },
                    { 19, 4, "A dozen large, cage-free brown eggs.", null, 0m, "https://example.com/images/brown-eggs.jpg", "Large Brown Eggs", 2.99m },
                    { 20, 4, "A 1-gallon jug of fresh and creamy whole milk.", null, 0m, "https://example.com/images/whole-milk.jpg", "Whole Milk", 3.49m },
                    { 21, 4, "A 1-pound package of unsalted butter.", null, 0m, "https://example.com/images/unsalted-butter.jpg", "Unsalted Butter", 4.49m },
                    { 22, 4, "A 1-pound block of sharp cheddar cheese.", null, 0m, "https://example.com/images/cheddar-cheese.jpg", "Sharp Cheddar Cheese", 5.99m },
                    { 23, 4, "A 32-ounce container of plain, non-fat Greek yogurt.", null, 0m, "https://example.com/images/greek-yogurt.jpg", "Greek Yogurt", 4.99m },
                    { 24, 4, "A 1-pint carton of heavy whipping cream.", null, 0m, "https://example.com/images/heavy-cream.jpg", "Heavy Cream", 2.99m },
                    { 25, 5, "A 10-ounce bag of crispy and delicious classic potato chips.", null, 0m, "https://example.com/images/potato-chips.jpg", "Classic Potato Chips", 3.49m },
                    { 26, 5, "A 3.5-ounce bar of rich and smooth dark chocolate.", null, 0m, "https://example.com/images/dark-chocolate.jpg", "Dark Chocolate Bar", 2.99m },
                    { 27, 5, "A 1-pound bag of soft and chewy assorted gummy bears.", null, 0m, "https://example.com/images/gummy-bears.jpg", "Gummy Bears", 3.99m },
                    { 28, 5, "A 16-ounce jar of crunchy and salted peanuts.", null, 0m, "https://example.com/images/salted-peanuts.jpg", "Salted Peanuts", 4.29m },
                    { 29, 5, "A 7-ounce bag of air-popped popcorn coated in white cheddar.", null, 0m, "https://example.com/images/white-cheddar-popcorn.jpg", "White Cheddar Popcorn", 3.79m },
                    { 30, 5, "A 12-ounce bag of crunchy and salty pretzel sticks.", null, 0m, "https://example.com/images/pretzel-sticks.jpg", "Pretzel Sticks", 2.99m },
                    { 31, 6, "A 1-pound loaf of freshly baked sourdough bread.", null, 0m, "https://example.com/images/sourdough-bread.jpg", "Sourdough Bread", 3.99m },
                    { 32, 6, "A pack of 12 soft and chewy chocolate chip cookies.", null, 0m, "https://example.com/images/chocolate-chip-cookies.jpg", "Chocolate Chip Cookies", 4.49m },
                    { 33, 6, "A pack of 4 delicious and moist blueberry muffins.", null, 0m, "https://example.com/images/blueberry-muffins.jpg", "Blueberry Muffins", 3.99m },
                    { 34, 6, "A freshly baked and crusty French baguette.", null, 0m, "https://example.com/images/french-baguette.jpg", "French Baguette", 2.49m },
                    { 35, 6, "A pack of 6 freshly baked cinnamon rolls with icing.", null, 0m, "https://example.com/images/cinnamon-rolls.jpg", "Cinnamon Rolls", 5.99m },
                    { 36, 6, "A 1-pound loaf of freshly baked whole wheat bread.", null, 0m, "https://example.com/images/whole-wheat-bread.jpg", "Whole Wheat Bread", 3.49m },
                    { 37, 7, "A 64-ounce bottle of 100% freshly squeezed orange juice.", null, 0m, "https://example.com/images/orange-juice.jpg", "Orange Juice", 4.49m },
                    { 38, 7, "A pack of 24 16.9-ounce bottles of purified water.", null, 0m, "https://example.com/images/bottled-water.jpg", "Bottled Water", 3.99m },
                    { 39, 7, "A box of 20 green tea bags, perfect for a healthy and refreshing drink.", null, 0m, "https://example.com/images/green-tea.jpg", "Green Tea", 3.49m },
                    { 40, 7, "A pack of 12 12-ounce cans of refreshing cola soda.", null, 0m, "https://example.com/images/cola-soda.jpg", "Cola Soda", 4.99m },
                    { 41, 7, "A pack of 8 20-ounce bottles of electrolyte-enhanced sports drink.", null, 0m, "https://example.com/images/sports-drink.jpg", "Sports Drink", 6.49m },
                    { 42, 7, "A 64-ounce carton of unsweetened almond milk.", null, 0m, "https://example.com/images/almond-milk.jpg", "Almond Milk", 3.79m },
                    { 43, 8, "A pack of 12 double rolls of soft and strong 2-ply toilet paper.", null, 0m, "https://example.com/images/toilet-paper.jpg", "Toilet Paper", 6.99m },
                    { 44, 8, "A pack of 6 big rolls of absorbent and durable paper towels.", null, 0m, "https://example.com/images/paper-towels.jpg", "Paper Towels", 5.49m },
                    { 45, 8, "A 32-ounce bottle of all-purpose cleaner, suitable for various surfaces.", null, 0m, "https://example.com/images/all-purpose-cleaner.jpg", "All-Purpose Cleaner", 2.99m },
                    { 46, 8, "A 100-ounce bottle of liquid laundry detergent, enough for 64 loads.", null, 0m, "https://example.com/images/laundry-detergent.jpg", "Laundry Detergent", 9.99m },
                    { 47, 8, "A 24-ounce bottle of dishwashing liquid, tough on grease and gentle on hands.", null, 0m, "https://example.com/images/dishwashing-liquid.jpg", "Dishwashing Liquid", 2.79m },
                    { 48, 8, "A pack of 40 13-gallon tall kitchen drawstring garbage bags.", null, 0m, "https://example.com/images/garbage-bags.jpg", "Garbage Bags", 7.49m },
                    { 49, 9, "A 4.7-ounce tube of fluoride toothpaste for cavity protection.", null, 0m, "https://example.com/images/toothpaste.jpg", "Toothpaste", 3.49m },
                    { 50, 9, "A 12-ounce bottle of moisturizing shampoo for all hair types.", null, 0m, "https://example.com/images/shampoo.jpg", "Shampoo", 4.99m },
                    { 51, 9, "An 18-ounce bottle of nourishing body wash for soft and smooth skin.", null, 0m, "https://example.com/images/body-wash.jpg", "Body Wash", 5.49m },
                    { 52, 9, "A 2.7-ounce stick of antiperspirant deodorant for 24-hour protection.", null, 0m, "https://example.com/images/deodorant.jpg", "Deodorant", 3.99m },
                    { 53, 9, "A box of 120 2-ply facial tissues, soft and gentle on the skin.", null, 0m, "https://example.com/images/facial-tissues.jpg", "Facial Tissues", 2.29m },
                    { 54, 9, "An 8-ounce bottle of hand sanitizer, kills 99.9% of germs.", null, 0m, "https://example.com/images/hand-sanitizer.jpg", "Hand Sanitizer", 3.79m },
                    { 55, 10, "A bottle of 100 200mg ibuprofen tablets for pain relief.", null, 0m, "https://example.com/images/ibuprofen.jpg", "Ibuprofen", 7.99m },
                    { 56, 10, "A bottle of 60 daily multivitamin tablets for overall health.", null, 0m, "https://example.com/images/multivitamins.jpg", "Multivitamins", 9.49m },
                    { 57, 10, "A box of 30 non-drowsy allergy relief tablets.", null, 0m, "https://example.com/images/allergy-relief.jpg", "Allergy Relief", 6.99m },
                    { 58, 10, "A 4-ounce bottle of cough suppressant syrup for cold and flu relief.", null, 0m, "https://example.com/images/cough-suppressant.jpg", "Cough Suppressant", 5.49m },
                    { 59, 10, "A box of 100 assorted sizes adhesive bandages for wound protection.", null, 0m, "https://example.com/images/band-aids.jpg", "Band-Aids", 4.29m },
                    { 60, 10, "A bottle of 100 500mg extra strength acetaminophen caplets for pain and fever relief.", null, 0m, "https://example.com/images/acetaminophen.jpg", "Acetaminophen", 7.49m },
                    { 61, 11, "A powerful 700-watt countertop blender with a 40-ounce glass jar.", null, 0m, "https://example.com/images/blender.jpg", "Blender", 49.99m },
                    { 62, 11, "A 1000-watt countertop microwave oven with a 1.1 cubic feet capacity.", null, 0m, "https://example.com/images/microwave-oven.jpg", "Microwave Oven", 89.99m },
                    { 63, 11, "A 2-slice toaster with 7 browning settings and a bagel function.", null, 0m, "https://example.com/images/toaster.jpg", "Toaster", 29.99m },
                    { 64, 11, "A 6-quart programmable slow cooker with a digital timer and removable stoneware.", null, 0m, "https://example.com/images/slow-cooker.jpg", "Slow Cooker", 59.99m },
                    { 65, 11, "A 1.7-liter stainless steel electric kettle with auto shut-off and boil-dry protection.", null, 0m, "https://example.com/images/electric-kettle.jpg", "Electric Kettle", 39.99m },
                    { 66, 11, "A HEPA-filter air purifier with 3 fan speeds for rooms up to 300 sq. ft.", null, 0m, "https://example.com/images/air-purifier.jpg", "Air Purifier", 99.99m },
                    { 67, 12, "A 20V cordless drill with a 2-speed gearbox and a 3/8-inch keyless chuck.", null, 0m, "https://example.com/images/cordless-drill.jpg", "Cordless Drill", 59.99m },
                    { 68, 12, "A 9-piece paint roller set including a tray, roller frame, and various roller covers.", null, 0m, "https://example.com/images/paint-roller-set.jpg", "Paint Roller Set", 14.99m },
                    { 69, 12, "A 16-ounce claw hammer with a fiberglass handle for durability and comfort.", null, 0m, "https://example.com/images/hammer.jpg", "Hammer", 12.99m },
                    { 70, 12, "A 25-foot retractable tape measure with a durable, impact-resistant case.", null, 0m, "https://example.com/images/tape-measure.jpg", "Tape Measure", 9.99m },
                    { 71, 12, "A 10-piece screwdriver set, including various flathead and Phillips sizes.", null, 0m, "https://example.com/images/screwdriver-set.jpg", "Screwdriver Set", 19.99m },
                    { 72, 12, "A retractable utility knife with a comfortable grip and quick blade change.", null, 0m, "https://example.com/images/utility-knife.jpg", "Utility Knife", 6.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DiscountId",
                table: "Products",
                column: "DiscountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Discounts");
        }
    }
}
