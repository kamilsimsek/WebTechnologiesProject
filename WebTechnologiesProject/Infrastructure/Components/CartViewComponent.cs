using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebTechnologiesProject.Models;
using WebTechnologiesProject.Models.ViewModels;

namespace WebTechnologiesProject.Infrastructure.Components
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            CartViewModel smallCartVM;

            if(cart == null ||cart.Count==0)
            {
                smallCartVM = null;
            }
            else
            {
                smallCartVM = new()
                {
                    NumberOfItems = cart.Sum(x => x.Quantity),
                    TotalAmount = cart.Sum(x => x.Quantity * x.Price)
                };
            }
            return View(smallCartVM);
        }
        
    }
}
