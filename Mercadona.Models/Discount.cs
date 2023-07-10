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
        public int DiscountValue { get; set; }

        [DisplayName("Start Date")]
        [Required]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
    }
}
