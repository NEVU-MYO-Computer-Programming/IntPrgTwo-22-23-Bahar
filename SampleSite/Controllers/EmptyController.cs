using Microsoft.AspNetCore.Mvc;

namespace SampleSite.Controllers
{
    public class EmptyController : Controller
    {
        public IActionResult Index() //Action -> Aksiyon 
        {
            return View();
        }

        public IActionResult Oylesine()
        {
            return View("Farkli");
        }

        public IActionResult GorunumsuzAction()
        {
            return View("Index");
        }

        public int AmacsizMetod() // bu bir action değildir
        {
            return 5;
        }
    }
}
