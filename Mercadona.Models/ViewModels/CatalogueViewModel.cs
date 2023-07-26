using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

/// <summary>
/// Namespace for Mercadona.Models.ViewModels.
/// </summary>
namespace Mercadona.Models.ViewModels
{
    /// <summary>
    /// Defines the properties for the CatalogueViewModel class.
    /// </summary>
    public class CatalogueViewModel
    {
        /// <summary>
        /// Gets or sets the Products of the view model. This is a list of Product instances.
        /// </summary>
        [ValidateNever]
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the Categories of the view model. This is a list of Category instances.
        /// </summary>
        [ValidateNever]
        public IEnumerable<Category> Categories { get; set; }
    }
}
