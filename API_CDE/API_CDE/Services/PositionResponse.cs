using API_CDE.Data;
using API_CDE.Models;

namespace API_CDE.Services
{
    public class PositionResponse : IPosition
    {
        private readonly ApplicationDBContext _context;
        public PositionResponse(ApplicationDBContext context) => _context = context;

        public Position AddPostion(string name, int idPostionGroup)
        {
            try
            {
                var poGr = new Position()
                {
                    PositionName = name,
                    IdPoGr = idPostionGroup
                };
                _context.Positions.Add(poGr);
                _context.SaveChanges();
                return poGr;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Position GetPosition(int id)
        {
            var position = _context.Positions.Find(id);
            if (position == null)
                return null;
            return position;
        }

        public IEnumerable<Position> PositionList()
        {
            return _context.Positions;
        }

        public Position UpdatePosition(int id, string name)
        {
            var position = _context.Positions.Find(id);
            if (position == null)
                return null;
            position.PositionName = name;
            _context.SaveChanges();
            return position;
        }
    }
}
