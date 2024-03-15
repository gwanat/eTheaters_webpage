using System.ComponentModel.DataAnnotations;

namespace eTheaters.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Play Play { get; set; }
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
