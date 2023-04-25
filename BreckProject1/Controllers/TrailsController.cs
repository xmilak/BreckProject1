using Microsoft.AspNetCore.Mvc;

namespace BreckProject1.Controllers
{
    public class Trails : Controller
    {
        private readonly ITrailsRepo repo;

        public Trails(ITrailsRepo repo)
        {
            this.repo = repo;
        }

        
        
        public IActionResult Index(int peak)
        {
            if (peak == 0)
            {
               
                    var allTrails = repo.GetAllTrails();
                    return View(allTrails);
                
            }
             
            var trails = repo.GetTrailsForPeak(peak);
            return View(trails);
        }
    }
}
