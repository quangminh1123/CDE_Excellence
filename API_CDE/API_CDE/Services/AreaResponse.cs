using API_CDE.Data;
using API_CDE.Models;

namespace API_CDE.Services
{
    public class AreaResponse : IArea
    {
        private readonly ApplicationDBContext _context;
        public AreaResponse(ApplicationDBContext context) => _context = context;

        public Area AddArea(string code, string name)
        {
            try
            {
                var area = new Area()
                {
                    AreaCode = code,
                    AreaName = name
                };
                _context.Areas.Add(area);
                _context.SaveChanges();
                return area;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<Area> AreaList()
        {
            return _context.Areas;
        }

        public string DeleteArea(int id)
        {
            try
            {
                var area = _context.Areas.Find(id);
                if (area == null)
                    return "Area not found";
                _context.Areas.Remove(area);
                _context.SaveChanges();
                return "Delete Success";
            }
            catch (Exception)
            {

                return $"Area with code {id} cannot remove because area has user";
            }
        }

        public Area GetAreaById(int id)
        {
            var area = _context.Areas.Find(id);
            if (area == null)
                return null;
            return area;
        }

        public IEnumerable<Area> SearchArea(string keyword)
        {
            return _context.Areas.Where(x => x.AreaName.Contains(keyword));
        }

        public Area UpdateArea(int id, string name)
        {
            try
            {
                var area = _context.Areas.Find(id);
                if (area == null)
                    return null;
                area.AreaName = name;
                _context.SaveChanges();
                return area;

            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
