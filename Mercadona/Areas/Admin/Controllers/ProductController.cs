using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;
using Mercadona.Models.ViewModels;
using Mercadona.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Reflection.PortableExecutable;


/// <summary>
/// Handles the functionality related to products, including viewing, creating, editing, and deleting products.
/// </summary>
namespace Mercadona.Areas.Admin.Controllers
{
    /// <summary>
    /// ProductController is responsible for handling CRUD operations for products.
    /// </summary>
    /// <remarks>
    /// This controller is decorated with the Authorize attribute, allowing only users with the "Admin" role to use its methods.
    /// </remarks>
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        /// <summary>
        /// Initializes a new instance of the ProductController class.
        /// </summary>
        /// <param name="unitOfWork">Unit of Work pattern, used for manipulating database records.</param>
        /// <param name="webHostEnvironment">The hosting environment this application is running in.</param>
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Lists all products.
        /// </summary>
        /// <returns>View displaying the list of products.</returns>
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount").ToList();
            return View(objProductList);
        }

        /// <summary>
        /// Prepares the form for creating a new product or updating an existing one.
        /// </summary>
        /// <param name="id">ID of the product, if null or 0 a new product will be created.</param>
        /// <returns>View displaying the form for creating or updating a product.</returns>
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ProductViewModel productViewModel = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                DiscountList = _unitOfWork.Discount.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                Product = new Product()
            };
            if (id == null || id == 0)
            {
                //create
                return View(productViewModel);
            }
            else
            {
                //update
                productViewModel.Product = _unitOfWork.Product.Get(x => x.Id == id);
                return View(productViewModel);
            }
        }

        /// <summary>
        /// Handles the submission of a form for creating or updating a product.
        /// </summary>
        /// <param name="productViewModel">ViewModel representing the product.</param>
        /// <param name="file">Image file associated with the product.</param>
        /// <returns>Redirects to index action after successful creation/update, otherwise returns the same view for displaying validation errors.</returns>
        [HttpPost, ActionName("Upsert")]
        public IActionResult UpsertPost(ProductViewModel productViewModel, IFormFile file)
        {
            if(file == null)
            {
                ModelState.AddModelError("ImageUpload", "Please choose an image for the product.");
                productViewModel.CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                productViewModel.DiscountList = _unitOfWork.Discount.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

                return View(productViewModel);
            }
            else
            {
                bool result = false;
                Dictionary<string, List<byte[]>> _fileSignatures = new()
                {
                    { ".jpeg", new List<byte[]>
                        {
                            new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                            new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                            new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                            new byte[] { 0xFF, 0xD8, 0xFF, 0xEE },
                            new byte[] { 0xFF, 0xD8, 0xFF, 0xDB },
                        }
                    },
                    { ".jpg", new List<byte[]>
                        {
                            new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                            new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                            new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
                            new byte[] { 0xFF, 0xD8, 0xFF, 0xEE },
                            new byte[] { 0xFF, 0xD8, 0xFF, 0xDB },
                        }
                    },
                    { ".png", new List<byte[]> { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } } },
                };

                using (var reader = new BinaryReader(file.OpenReadStream()))
                {
                    var signatures = _fileSignatures.Values.SelectMany(x => x).ToList();  // flatten all signatures to single list
                    var headerBytes = reader.ReadBytes(_fileSignatures.Max(m => m.Value.Max(n => n.Length)));
                    result = signatures.Any(signature => headerBytes.Take(signature.Length).SequenceEqual(signature));
                }
                if(result == false)
                {
                    ModelState.AddModelError("ImageUpload", "Please choose a valid .jpg, .png .jpeg Image.");
                    productViewModel.CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    });
                    productViewModel.DiscountList = _unitOfWork.Discount.GetAll().Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    });

                    return View(productViewModel);
                }
                else
                {
                    if(file.Length > 5 * 1024 * 1024)
                    {
                        ModelState.AddModelError("ImageUpload", "Maximum image size is 5Mb.");
                        productViewModel.CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                        {
                            Text = x.Name,
                            Value = x.Id.ToString()
                        });
                        productViewModel.DiscountList = _unitOfWork.Discount.GetAll().Select(x => new SelectListItem
                        {
                            Text = x.Name,
                            Value = x.Id.ToString()
                        });

                        return View(productViewModel);
                    }
                    else
                    {
                        if (ModelState.IsValid)
                        {
                            List<Product> products = new List<Product>();
                            products = _unitOfWork.Product.GetAll().ToList();
                            if (!products.Any(x => x.Name.ToLower() == productViewModel.Product.Name.ToLower()))
                            {
                                string wwwRootPath = _webHostEnvironment.WebRootPath;
                                if (file != null)
                                {
                                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                                    string productPath = Path.Combine(wwwRootPath, @"img\product");

                                    if (!string.IsNullOrEmpty(productViewModel.Product.ImageUrl))
                                    {
                                        //delete the old image
                                        var oldImagePath = Path.Combine(wwwRootPath, productViewModel.Product.ImageUrl.TrimStart('\\'));
                                        if (System.IO.File.Exists(oldImagePath))
                                        {
                                            System.IO.File.Delete(oldImagePath);
                                        }
                                    }

                                    using (var filestream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                                    {
                                        file.CopyTo(filestream);
                                    }


                                    productViewModel.Product.ImageUrl = @"\img\product\" + filename;

                                }

                                if (productViewModel.Product.Id == 0)
                                {
                                    _unitOfWork.Product.Add(productViewModel.Product);
                                }
                                else
                                {
                                    _unitOfWork.Product.Update(productViewModel.Product);
                                }

                                _unitOfWork.Save();
                                TempData["success"] = "Product created successfully";
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                productViewModel.CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                                {
                                    Text = x.Name,
                                    Value = x.Id.ToString()
                                });
                                productViewModel.DiscountList = _unitOfWork.Discount.GetAll().Select(x => new SelectListItem
                                {
                                    Text = x.Name,
                                    Value = x.Id.ToString()
                                });

                                Span<char> destination = stackalloc char[1];
                                TempData["error"] = $"The \"{char.ToUpper(productViewModel.Product.Name[0]) + productViewModel.Product.Name.Substring(1)}\" product already exists";
                                
                                return View(productViewModel);
                            }
                        }
                        else
                        {

                            productViewModel.CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                            {
                                Text = x.Name,
                                Value = x.Id.ToString()
                            });
                            productViewModel.DiscountList = _unitOfWork.Discount.GetAll().Select(x => new SelectListItem
                            {
                                Text = x.Name,
                                Value = x.Id.ToString()
                            });

                            return View(productViewModel);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the discount details for a product.
        /// </summary>
        /// <param name="pId">ID of the product.</param>
        /// <returns>JSON containing discount details associated with a product.</returns>
        [HttpPost]
        public ActionResult GetDiscountData(int? pId)
        {
            var discount = _unitOfWork.Discount.Get(x => x.Id == pId);
            if (discount != null)
            {
                discount.StartDate.ToString("yyyy-MM-dd");
                discount.EndDate.GetValueOrDefault().ToString("yyyy-MM-dd");
                return Json(discount);
            }
            else
            {
                return Json(null);
            }
        }

        #region API CALLS
        /// <summary>
        /// Lists all products as a JSON response.
        /// </summary>
        /// <returns>JSON response containing all products.</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount").ToList();
            return Json(new { data = objProductList });
        }

        /// <summary>
        /// Deletes a product with the specified id.
        /// </summary>
        /// <param name="id">ID of the product to be deleted.</param>
        /// <returns>JSON response containing the result of the deletion operation.</returns>
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.Get(x => x.Id == id);
            if (productToBeDeleted == null)
            {
                return Json(new { success = false, title = "Error while deleting", message = " ", button = "Damn" });
            }

            if (productToBeDeleted.ImageUrl != null)
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

            }
            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, title = "Discount deleted successfully", message = " ", button = "Nice" });
        }

        #endregion
    }
}
