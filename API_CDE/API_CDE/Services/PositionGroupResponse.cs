using API_CDE.Data;
using API_CDE.Models;

namespace API_CDE.Services
{
    public class PositionGroupResponse : IPositionGroup
    {
        private readonly ApplicationDBContext _context;
        public PositionGroupResponse(ApplicationDBContext context) => _context = context;

        public PositionGroup AddPositionGroup(string name)
        {
            try
            {
                var poGr = new PositionGroup()
                {
                    Name = name
                };
                _context.PositionGroups.Add(poGr);
                _context.SaveChanges();
                return poGr;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string DeletePositionGroup(int id)
        {
            try
            {
                var poGr = _context.PositionGroups.Find(id);
                if (poGr == null)
                    return "Not found";
                _context.PositionGroups.Remove(poGr);
                _context.SaveChanges();
                return "Delete Success";
            }
            catch (Exception)
            {

                return "Cannot remove";
            }
        }

        public PositionGroup GetPositionGroupById(int id)
        {
            var poGr = _context.PositionGroups.Find(id);
            if (poGr == null)
                return null;
            return poGr;
        }

        public IEnumerable<PositionGroup> PositionGroupList()
        {
           return _context.PositionGroups;
        }

        public PositionGroup UpdatePositionGroup(int id, string name)
        {
            var poGr = _context.PositionGroups.Find(id);
            if (poGr == null)
                return null;
            poGr.Name = name;
            _context.SaveChanges();
            return poGr;
        }
    }
}
