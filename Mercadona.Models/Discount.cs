/**
 *@file Discount.cs
 *brief The discount class variables that defines a discount. 
*/
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mercadona.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Discount Name")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [DisplayName("% Dicsount")]
        [Required]
        [Range(1, 99, ErrorMessage = "The discount must be between 1% and 99%")]
        public int DiscountValue { get; set; }

        [DisplayName("Start Date")]
        [Required]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
    }
}
