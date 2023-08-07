using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Routing;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Namespace for Mercadona.Models.
/// </summary>
namespace Mercadona.Models
{
    /// <summary>
    /// Defines the properties for the Product class.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the Id of the product.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the CategoryId of the product.
        /// </summary>
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the Category object of the product.
        /// </summary>
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        /// <summary>
        /// Gets or sets the Name of the product.
        /// </summary>
        [DisplayName("Product Name")]
        //[MaxLength(50)]
        [MinLength(3)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description of the product.
        /// </summary>
        [DisplayName("Product Description")]
        [Required]
        [StringLength(100)]
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets the Image Url of the product.
        /// </summary>

        [DisplayName("Image Url")]
        [Required]
        [ValidateNever]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the Price of the product.
        /// </summary>
        [DisplayName("Price")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "The price must be superior to 0")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the DiscountId of the product.
        /// </summary>
        [DisplayName("Discount")]
        public int? DiscountId { get; set; }

        /// <summary>
        /// Gets or sets the Discount object of the product.
        /// </summary>
        [ForeignKey("DiscountId")]
        [ValidateNever]
        public Discount? Discount { get; set; }

        /// <summary>
        /// Gets or sets the DiscountedPrice of the product.
        /// </summary>
        [DisplayName("Disc. Price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The discounted price must be superior to 0")]
        public decimal? DiscountedPrice { get; set; }
    }
}
