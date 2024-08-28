using ecom.Models;

namespace ecom.ViewModels
{
    public class DashboardViewModel
    {
        public List<Product?> Products { get; set; }

        public List<TodoList?> TodoLists { get; set; }

        public List<MyMessage> MyMessages { get; set; }

        public List<Post> Posts { get; set; }
    }
}
