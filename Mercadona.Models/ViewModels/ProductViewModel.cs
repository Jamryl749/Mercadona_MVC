using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

/// <summary>
/// Namespace for Mercadona.Models.ViewModels.
/// </summary>
namespace Mercadona.Models.ViewModels
{
    /// <summary>
    /// Defines the properties for the ProductViewModel class.
    /// </summary>
    public class ProductViewModel
    {
        /// <summary>
        /// Gets or sets the Product of the view model.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the CategoryList of the view model. This is a list of SelectListItem, each representing a Category.
        /// </summary>
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        /// <summary>
        /// Gets or sets the DiscountList of the view model. This is a list of SelectListItem, each representing a Discount.
        /// </summary>
        [ValidateNever]
        public IEnumerable<SelectListItem> DiscountList { get; set; }
    }
}
