using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(){
            return View();
        }
        
    }
}