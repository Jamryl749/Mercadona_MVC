using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mercadona.Models.ViewModels
{
    public class CatalogueViewModel
    {
        [ValidateNever]
        public IEnumerable<Product> Products { get; set; }
        [ValidateNever]
        public IEnumerable<Category> Categories { get; set; }
    }
}
