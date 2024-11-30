using API_CDE.Services;
using Microsoft.AspNetCore.Authorization;
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

        //[Authorize(Roles = "Owner")]
        [HttpGet]
        public ActionResult Get(int page = 1) //int pageSize
        {
            int pagesize = 3; //mặc định 3 items trên 1 trang
            var skip = (page - 1) * pagesize;
            var areas = area.AreaList().Skip(skip).Take(pagesize).ToList();

            if (areas == null || !areas.Any())
            {
                return NotFound("Không có dữ liệu");
            }

            var totalItems = area.AreaList().Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pagesize);
            //var result = new
            //{
            //    Page = page,
            //    PageSize = 3,
            //    TotalItems = totalItems,
            //    TotalPages = totalPages,
            //    Items = areas
            //}
            return Ok(areas);
        }


        //[Authorize(Roles = "Owner")]
        [HttpGet("{id}")]
        public ActionResult GetId(int id)
        {
            return Ok(area.GetAreaById(id));
        }

        //[Authorize(Roles = "Owner")]
        [HttpGet]
        [Route("Search")]
        public ActionResult Search(string keyword)
        {
            return Ok(area.SearchArea(keyword));
        }

        //[Authorize(Roles = "Owner")]
        [HttpPost]
        public ActionResult Add(string code, string name)
        {
            var ar = area.AddArea(code, name);
            if (ar == null)
                return BadRequest();
            return CreatedAtAction("Add", ar);
        }

        //[Authorize(Roles = "Owner")]
        [HttpPut("{id}")]
        public ActionResult Update(int id, string name)
        {
            var are = area.UpdateArea(id, name);
            if (are == null)
                return BadRequest();
            return Ok(are);
        }

        //[Authorize(Roles = "Owner")]
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
