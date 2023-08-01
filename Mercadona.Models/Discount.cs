using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Namespace for Mercadona.Models.
/// </summary>
namespace Mercadona.Models
{
    /// <summary>
    /// Defines the properties for the Discount class.
    /// </summary>
    public class Discount
    {
        /// <summary>
        /// Gets or sets the Id of the discount.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name of the discount.
        /// </summary>
        [DisplayName("Discount Name")]
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the DiscountValue of the discount.
        /// </summary>
        [DisplayName("% Discount")]
        [Required]
        [Range(1, 99, ErrorMessage = "The discount must be between 1% and 99%")]
        public int DiscountValue { get; set; }

        /// <summary>
        /// Gets or sets the StartDate of the discount.
        /// </summary>
        [DisplayName("Start Date")]
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the EndDate of the discount.
        /// </summary>
        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
    }
}
