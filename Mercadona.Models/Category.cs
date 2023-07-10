using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mercadona.Models
{
	public class Category
	{
        [Key]
        public int Id { get; set; }
		[DisplayName("Category Name")]
        [Required]
        [MaxLength(30)]
		public string Name { get; set; } = string.Empty;
        [DisplayName("Category Url")]
        public string Url { get; set; } = string.Empty;
    }
}
