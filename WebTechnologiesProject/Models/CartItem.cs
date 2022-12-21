using Microsoft.Extensions.Primitives;

namespace WebTechnologiesProject.Models
{
    public class CartItem
    {
        public long MovieId { get; set; }
        public string MovieName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total 
        { 
            get 
            {
                return Quantity * Price;
            } 
        }
        public string Image { get; set; }

        public CartItem()
        {
        }

        public CartItem(Product product)
        {
            MovieId = product.Id;
            MovieName = product.Name;
            Price = product.Price;
            Quantity = 1;
            Image = product.Image;
        }


    }
}
