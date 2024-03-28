using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mycloth_website.Areas.Identity.Data;
using Mycloth_website.Models;
using Mycloth_website.Services;
using System.Diagnostics;
using WebApplication1.NewFolder;
using Mycloth_website.Lists;

namespace Mycloth_website.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContex _db;
        private readonly ItemService1 _itemService;
        private const int PageSize = 12;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContex db, ItemService1 itemService)
        {
            _logger = logger;
            _userManager = userManager;
            _db = db;
            _itemService = itemService;
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Index(int page = 1)
        {
            var items = _itemService.GetMenCategory();
            var totalItems = items.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);
            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            var items1 = _itemService.GetWomenCategory();
            var totalItems1 = items1.Count();
            var totalPages1 = (int)Math.Ceiling((double)totalItems1 / PageSize);
            var paginatedItems1 = items1.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            var items2 = _itemService.GetShoesCategory();
            var totalItems2 = items1.Count();
            var totalPages2 = (int)Math.Ceiling((double)totalItems2 / PageSize);
            var paginatedItems2 = items2.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            var items3 = _itemService.GetElectronicsCategory();
            var totalItems3 = items1.Count();
            var totalPages3 = (int)Math.Ceiling((double)totalItems3 / PageSize);
            var paginatedItems3 = items3.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            var items4 = _itemService.GetFrunitureCategory();
            var totalItems4 = items1.Count();
            var totalPages4 = (int)Math.Ceiling((double)totalItems4 / PageSize);
            var paginatedItems4 = items4.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            var items5 = _itemService.GetCleaningCategory();
            var totalItems5 = items1.Count();
            var totalPages5 = (int)Math.Ceiling((double)totalItems5 / PageSize);
            var paginatedItems5 = items5.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            var items6 = _itemService.GettvCategory();
            var totalItems6 = items1.Count();
            var totalPages6 = (int)Math.Ceiling((double)totalItems6 / PageSize);
            var paginatedItems6 = items6.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            var items7 = _itemService.GetToysCategory();
            var totalItems7 = items1.Count();
            var totalPages7 = (int)Math.Ceiling((double)totalItems7 / PageSize);
            var paginatedItems7 = items7.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            var items8 = _itemService.GetMobileCategory();
            var totalItems8 = items1.Count();
            var totalPages8 = (int)Math.Ceiling((double)totalItems8 / PageSize);
            var paginatedItems8 = items8.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            //var items2 = _itemService.GetKidsCategory();
            //var totalItems2 = 1;
            //var totalPages2 = (int)Math.Ceiling((double)totalItems2 / PageSize);
            //var paginatedItems2 = items2.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            var menPaginatedList = new PaginatedList<MenCategory>(paginatedItems, page, totalPages);
            var womenPaginatedList = new PaginatedList<WomenCategory>(paginatedItems1, page, totalPages1);
            var ShoesPaginatedList = new PaginatedList<ShoesCategory>(paginatedItems2, page, totalPages2);
            var ElectronicsPaginatedList = new PaginatedList<ElectronicsCategory>(paginatedItems3, page, totalPages3);
            var FruniturePaginatedList = new PaginatedList<FrunitureCategory>(paginatedItems4, page, totalPages4);
            var CleaningPaginatedList = new PaginatedList<CleaningCategory>(paginatedItems5, page, totalPages5);
            var tvPaginatedList = new PaginatedList<tvCategory>(paginatedItems6, page, totalPages6);
            var ToysPaginatedList = new PaginatedList<ToysCategory>(paginatedItems7, page, totalPages7);
            var MobilePaginatedList = new PaginatedList<MobileCategory>(paginatedItems8, page, totalPages8);

            //var kidPaginatedList = new PaginatedList<KidsCategory>(paginatedItems2, page, totalPages2);

            var viewModel = new IndexViewModel
            {
                MenItems = menPaginatedList,
                WomenItems = womenPaginatedList,
                ShoesItems  = ShoesPaginatedList,
                ElectronicsItems = ElectronicsPaginatedList,
                FrunitureItems = FruniturePaginatedList,
                CleaningItems = CleaningPaginatedList,
                tvItems = tvPaginatedList,
                ToysItems = ToysPaginatedList,
                MobileItems = MobilePaginatedList
                //KidItems = kidPaginatedList
            };
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();

            return View(viewModel);
        }

        public IActionResult Mans(int page = 1)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            var items = _itemService.GetMenCategory();

            var totalItems = items.Count();

            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            return View(new PaginatedList<MenCategory>(paginatedItems, page, totalPages));

        }

        public IActionResult MenSave(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            if (id == null)
            {
                return NotFound("ID Not Found");
            }
            var studentregister = _db.MenCategory.Find(id);
            var userData = new Cart()
            {
                ProductName = studentregister.ProductName,
                ProductImage = studentregister.ProductImage,
                ProductDescription = studentregister.ProductDescription,
                ProductPrice = studentregister.ProductPrice,
                DicountProductPrice = studentregister.DicountProductPrice
            };
            _db.Cart.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("Mans");
        }

        public IActionResult Shoes(int page = 1)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            var items = _itemService.GetShoesCategory();

            var totalItems = items.Count();

            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            return View(new PaginatedList<ShoesCategory>(paginatedItems, page, totalPages));

        }

        public IActionResult ShoesSave(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            if (id == null)
            {
                return NotFound("ID Not Found");
            }
            var studentregister = _db.ShoesCategory.Find(id);
            var userData = new Cart()
            {
                ProductName = studentregister.ProductName,
                ProductImage = studentregister.ProductImage,
                ProductDescription = studentregister.ProductDescription,
                ProductPrice = studentregister.ProductPrice,
                DicountProductPrice = studentregister.DicountProductPrice
            };
            _db.Cart.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("Shoes");
        }


        public IActionResult Electronics(int page = 1)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            var items = _itemService.GetElectronicsCategory();

            var totalItems = items.Count();

            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            return View(new PaginatedList<ElectronicsCategory>(paginatedItems, page, totalPages));

        }

        public IActionResult ElectronicsSave(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            if (id == null)
            {
                return NotFound("ID Not Found");
            }
            var studentregister = _db.ElectronicsCategory.Find(id);
            var userData = new Cart()
            {
                ProductName = studentregister.ProductName,
                ProductImage = studentregister.ProductImage,
                ProductDescription = studentregister.ProductDescription,
                ProductPrice = studentregister.ProductPrice,
                DicountProductPrice = studentregister.DicountProductPrice
            };
            _db.Cart.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("Electronics");
        }


        public IActionResult Fruniture(int page = 1)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            var items = _itemService.GetFrunitureCategory();

            var totalItems = items.Count();

            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            return View(new PaginatedList<FrunitureCategory>(paginatedItems, page, totalPages));

        }

        public IActionResult FrunitureSave(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            if (id == null)
            {
                return NotFound("ID Not Found");
            }
            var studentregister = _db.FrunitureCategory.Find(id);
            var userData = new Cart()
            {
                ProductName = studentregister.ProductName,
                ProductImage = studentregister.ProductImage,
                ProductDescription = studentregister.ProductDescription,
                ProductPrice = studentregister.ProductPrice,
                DicountProductPrice = studentregister.DicountProductPrice
            };
            _db.Cart.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("Fruniture");
        }


        public IActionResult Cleaning(int page = 1)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            var items = _itemService.GetCleaningCategory();

            var totalItems = items.Count();

            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            return View(new PaginatedList<CleaningCategory>(paginatedItems, page, totalPages));

        }

        public IActionResult CleaningSave(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            if (id == null)
            {
                return NotFound("ID Not Found");
            }
            var studentregister = _db.CleaningCategory.Find(id);
            var userData = new Cart()
            {
                ProductName = studentregister.ProductName,
                ProductImage = studentregister.ProductImage,
                ProductDescription = studentregister.ProductDescription,
                ProductPrice = studentregister.ProductPrice,
                DicountProductPrice = studentregister.DicountProductPrice
            };
            _db.Cart.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("Cleaning");
        }


        public IActionResult tv(int page = 1)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            var items = _itemService.GettvCategory();

            var totalItems = items.Count();

            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            return View(new PaginatedList<tvCategory>(paginatedItems, page, totalPages));

        }

        public IActionResult tvSave(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            if (id == null)
            {
                return NotFound("ID Not Found");
            }
            var studentregister = _db.tvCategory.Find(id);
            var userData = new Cart()
            {
                ProductName = studentregister.ProductName,
                ProductImage = studentregister.ProductImage,
                ProductDescription = studentregister.ProductDescription,
                ProductPrice = studentregister.ProductPrice,
                DicountProductPrice = studentregister.DicountProductPrice
            };
            _db.Cart.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("tv");
        }

        public IActionResult Toys(int page = 1)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            var items = _itemService.GetToysCategory();

            var totalItems = items.Count();

            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            return View(new PaginatedList<ToysCategory>(paginatedItems, page, totalPages));

        }

        public IActionResult ToysSave(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            if (id == null)
            {
                return NotFound("ID Not Found");
            }
            var studentregister = _db.ToysCategory.Find(id);
            var userData = new Cart()
            {
                ProductName = studentregister.ProductName,
                ProductImage = studentregister.ProductImage,
                ProductDescription = studentregister.ProductDescription,
                ProductPrice = studentregister.ProductPrice,
                DicountProductPrice = studentregister.DicountProductPrice
            };
            _db.Cart.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("Toys");
        }
        public IActionResult Mobile(int page = 1)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            var items = _itemService.GetMobileCategory();

            var totalItems = items.Count();

            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            return View(new PaginatedList<MobileCategory>(paginatedItems, page, totalPages));

        }

        public IActionResult MobileSave(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            if (id == null)
            {
                return NotFound("ID Not Found");
            }
            var studentregister = _db.ShoesCategory.Find(id);
            var userData = new Cart()
            {
                ProductName = studentregister.ProductName,
                ProductImage = studentregister.ProductImage,
                ProductDescription = studentregister.ProductDescription,
                ProductPrice = studentregister.ProductPrice,
                DicountProductPrice = studentregister.DicountProductPrice
            };
            _db.Cart.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("Mobile");
        }
       

        public IActionResult Womens(int page = 1)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();

            var items = _itemService.GetWomenCategory();

            var totalItems = items.Count();

            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            return View(new PaginatedList1<WomenCategory>(paginatedItems, page, totalPages));

        }

        public IActionResult WomenSave(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            if (id == null)
            {
                return NotFound("ID Not Found");
            }
            var studentregister = _db.WomenCategory.Find(id);
            var userData = new Cart()
            {
                ProductName = studentregister.ProductName,
                ProductImage = studentregister.ProductImage,
                ProductDescription = studentregister.ProductDescription,
                ProductPrice = studentregister.ProductPrice,
                DicountProductPrice = studentregister.DicountProductPrice
            };
            _db.Cart.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("Womens");
        }


        public IActionResult MenDetails(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound("Data Not Found vipul");
            }
            var studentregister = _db.MenCategory.Find(id);
            if (studentregister == null)
            {
                return NotFound("Data Not Found");
            }
            var cart =  _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            return View(studentregister);
        }

        public IActionResult ShoesDetails(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound("Data Not Found Amit");
            }
            var studentregister = _db.ShoesCategory.Find(id);
            if (studentregister == null)
            {
                return NotFound("Data Not Found");
            }
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            return View(studentregister);
        }

        public IActionResult ElectronicsDetails(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound("Data Not Found Amit");
            }
            var studentregister = _db.ElectronicsCategory.Find(id);
            if (studentregister == null)
            {
                return NotFound("Data Not Found");
            }
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            return View(studentregister);
        }
        public IActionResult FrunitureDetails(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound("Data Not Found Amit");
            }
            var studentregister = _db.FrunitureCategory.Find(id);
            if (studentregister == null)
            {
                return NotFound("Data Not Found");
            }
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            return View(studentregister);
        }
        public IActionResult CleaningDetails(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound("Data Not Found Amit");
            }
            var studentregister = _db.CleaningCategory.Find(id);
            if (studentregister == null)
            {
                return NotFound("Data Not Found");
            }
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            return View(studentregister);
        }
        public IActionResult tvDetails(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound("Data Not Found Amit");
            }
            var studentregister = _db.tvCategory.Find(id);
            if (studentregister == null)
            {
                return NotFound("Data Not Found");
            }
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            return View(studentregister);
        }
        public IActionResult ToysDetails(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound("Data Not Found Amit");
            }
            var studentregister = _db.ToysCategory.Find(id);
            if (studentregister == null)
            {
                return NotFound("Data Not Found");
            }
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            return View(studentregister);
        }
        public IActionResult MobileDetails(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound("Data Not Found Amit");
            }
            var studentregister = _db.MobileCategory.Find(id);
            if (studentregister == null)
            {
                return NotFound("Data Not Found");
            }
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            return View(studentregister);
        }




        public IActionResult WomenDetails(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();

            if (id == null || id == 0)
            {
                return NotFound("Data Not Found vipul");
            }
            var studentregister = _db.WomenCategory.Find(id);
            if (studentregister == null)
            {
                return NotFound("Data Not Found");
            }
            return View(studentregister);
        }


       
        public IActionResult Cart(int page = 1)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();

            var items = _itemService.GetCart();

            var totalItems = items.Count();

            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            var paginatedItems = items.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            return View(new PaginatedList3<Cart>(paginatedItems, page, totalPages));
        }



        public IActionResult DeleteFromCart(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            var itemToDelete = _db.Cart.Find(id);
            if (itemToDelete == null)
            {
                return NotFound("ggwr"); // Return a 404 Not Found if the item is not found
            }

            _db.Cart.Remove(itemToDelete); // Remove the item from the cart
            _db.SaveChanges(); // Save changes to the database
            TempData["Message"] = "Item removed successfully";

            return RedirectToAction("Cart"); // Redirect back to the cart page
        }


        public IActionResult CartDetails(int id)
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            if (id == null)
            {
                return NotFound("ID Not Found");
            }
            var studentregister = _db.Cart.Find(id);
            if (studentregister == null)
            {
                return NotFound("Data Not Found");
            }
            return View(studentregister);
        }


        public IActionResult aboutUs()
        {
            var cart = _itemService.GetCart();
            var totalcart = cart.Count();
            TempData["totalItems"] = totalcart.ToString();
            return View();
        }

        public IActionResult ContactUs()
        {
            var cart = _itemService.GetCart();
            var totalcart = cart.Count();
            TempData["totalItems"] = totalcart.ToString();
            return View();
        }

        [HttpGet]
        public IActionResult AddMen()
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            return View();
        }

        [HttpPost]
        public IActionResult AddMen(MenCategory register)
        {
            var userData = new MenCategory()
            {
                ProductName = register.ProductName,
                ProductImage = register.ProductImage,
                ProductDescription = register.ProductDescription,
                ProductPrice = register.ProductPrice,
                DicountProductPrice = register.DicountProductPrice
            };
            _db.MenCategory.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddWomen()
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            return View();
        }

        [HttpPost]
        public IActionResult AddWomen(WomenCategory register)
        {
            var userData = new WomenCategory()
            {
                ProductName = register.ProductName,
                ProductImage = register.ProductImage,
                ProductDescription = register.ProductDescription,
                ProductPrice = register.ProductPrice,
                DicountProductPrice = register.DicountProductPrice
            };
            _db.WomenCategory.Add(userData);
            _db.SaveChanges();
            ViewBag.Status = 1;
            return RedirectToAction("AddWomen");
        }

        [HttpGet]
        public IActionResult AddKid()
        {
            var cart = _itemService.GetCart();

            var totalcart = cart.Count();

            TempData["totalItems"] = totalcart.ToString();
            return View();
        }

    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}