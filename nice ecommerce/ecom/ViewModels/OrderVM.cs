using ecom.Models;

namespace ecom.ViewModels
{
    public class OrderVM
    {
        public IEnumerable<OrderDetail> OrderDetail { get; set; }
    }
}
