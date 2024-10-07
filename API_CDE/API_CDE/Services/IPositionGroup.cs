using API_CDE.Models;

namespace API_CDE.Services
{
    public interface IPositionGroup
    {
        public IEnumerable<PositionGroup> PositionGroupList();
        public PositionGroup GetPositionGroupById(int id);
        public PositionGroup AddPositionGroup(string name);
        public PositionGroup UpdatePositionGroup(int id, string name);
        public string DeletePositionGroup(int id);
    }
}
