using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Namespace for Mercadona.Models.
/// </summary>
namespace Mercadona.Models
{
    /// <summary>
    /// Defines the properties for the Category class.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the Id of the category.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name of the category.
        /// </summary>
        [DisplayName("Category Name")]
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
