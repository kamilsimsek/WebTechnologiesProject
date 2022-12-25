using Microsoft.AspNetCore.Mvc;
using WebTechnologiesProject.Infrastructure;
using WebTechnologiesProject.Models;
using WebTechnologiesProject.Models.ViewModels;

namespace WebTechnologiesProject.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _context;

        public CartController(DataContext context1)
        {
            _context = context1;
        }
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart")??new List<CartItem>();
            CartPageViewModel CartVM = new()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };
            
            return View(CartVM);
        }

        public async Task<IActionResult> Add(int id)
        {
            Product movie = await _context.Products.FindAsync(id);
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItem cartItem = cart.Where(c=> c.MovieId==id).FirstOrDefault();
            if(cartItem == null)
            {
                cart.Add(new CartItem(movie));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            TempData["Success"] = "The product has been added";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Decrease(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            CartItem cartItem = cart.Where(c => c.MovieId == id).FirstOrDefault();
            if (cartItem.Quantity >1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(x => x.MovieId == id);
            }

            if(cart.Count ==0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            

            TempData["Success"] = "The product has been removed";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(x => x.MovieId == id);

            
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }



            TempData["Success"] = "The product has been removed";

            return RedirectToAction("Index");
        }


        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index");
        }
    }
}
