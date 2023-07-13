using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Mercadona.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [DisplayName("Product Name")]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [DisplayName("Product Description")]
        [Required]
        public string Desc { get; set; }

        [ValidateNever]
        [Required]
        public string ImageUrl { get; set; }

        [DisplayName("Price")]
        [Required]
        [Range(0.01, Double.MaxValue, ErrorMessage = "The price must be superior to 0")]
        public decimal Price { get; set; }

        [DisplayName("Discount")]
        public int? DiscountId { get; set; }

        [ForeignKey("DiscountId")]
        [ValidateNever]
        public Discount? Discount { get; set; }

        [DisplayName("Disc. Price")]
        [Range(Double.Epsilon, Double.MaxValue, ErrorMessage = "The discounted price must be superior to 0")]
        public decimal? DiscountedPrice { get; set; }
    }
}
