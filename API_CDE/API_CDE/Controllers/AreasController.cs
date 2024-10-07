using API_CDE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IArea area;
        public AreasController(IArea area)
        {
            this.area = area;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(area.AreaList());
        }

        [HttpGet("{id}")]
        public ActionResult GetId(int id)
        {
            return Ok(area.GetAreaById(id));
        }

        [HttpGet]
        [Route("Search")]
        public ActionResult Search(string keyword)
        {
            return Ok(area.SearchArea(keyword));
        }

        [HttpPost]
        public ActionResult Add(string code, string name)
        {
            var ar = area.AddArea(code, name);
            if (ar == null)
                return BadRequest();
            return CreatedAtAction("Add", ar);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, string name)
        {
            var are = area.UpdateArea(id, name);
            if (are == null)
                return BadRequest();
            return Ok(are);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            string ar = area.DeleteArea(id);
            if (ar == "Delete Success")
                return NoContent();
            else
                return BadRequest(ar);
        }
    }
}
