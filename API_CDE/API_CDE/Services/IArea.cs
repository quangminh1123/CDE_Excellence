using API_CDE.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Services
{
    public interface IArea
    {
        public IEnumerable<Area> AreaList();
        public Area GetAreaById(int id);
        public IEnumerable<Area> SearchArea(string keyword);
        public Area AddArea(string code, string name); 
        public Area UpdateArea(int id, string name);
        public string DeleteArea(int id);
    }
}
