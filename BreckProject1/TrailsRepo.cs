using BreckProject1.Models;
using Dapper;
using System.Data;

namespace BreckProject1
{
    public class TrailsRepo : ITrailsRepo
    {
        private readonly IDbConnection _conn;

        public TrailsRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Trails> GetAllTrails()
        {
            return _conn.Query<Trails>("SELECT * FROM trails;");
        }
        public IEnumerable<Trails> GetTrailsForPeak(int peak)
        {
            return _conn.Query<Trails>("SELECT * FROM trails WHERE peak = @peak;", new { peak });
        }

    }
}
