using ecom.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ecom.ViewModels
{
    public class RoleManagmentVM
    {
        public AppUser ApplicationUser { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }
    }
}
