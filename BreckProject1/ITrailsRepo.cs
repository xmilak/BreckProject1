using BreckProject1.Models;

namespace BreckProject1
{
    public interface ITrailsRepo
    {
        public IEnumerable<Trails> GetAllTrails();

        public IEnumerable<Trails> GetTrailsForPeak(int peak);
    }
    
}
