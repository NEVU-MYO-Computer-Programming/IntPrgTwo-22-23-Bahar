using Microsoft.AspNetCore.Mvc;
using SampleSite.Models;

namespace SampleSite.Controllers
{
    public class DutyController : Controller
    {
        public IActionResult Index()
        {
            List<Duty> dutyList = DataContext.globalDuties.ToList();

            return View(dutyList);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Duty entity)
        {

            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            DataContext.globalDuties.Add(entity);

            return RedirectToAction("Index");
        }
        //HttpGet metodu ile çalışır
        public IActionResult Delete(int id)
        {
            var silinecekDuty = DataContext.globalDuties.FirstOrDefault(x => x.ID == id);
            if (silinecekDuty == null)
            {
                TempData["hata"] = "Silinecek nesne bulunamadı.";
                return RedirectToAction("Index");
            }
            return View(silinecekDuty);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteComfirmed(int id)
        {

            var silinecekDuty = DataContext.globalDuties.FirstOrDefault(x => x.ID == id);
            if (silinecekDuty == null)
            {
                TempData["hata"] = "Silinecek nesne bulunamadı.";
                return RedirectToAction("Index");
            }
            DataContext.globalDuties.Remove(silinecekDuty);

            return RedirectToAction("Index");

        }

    }
}
