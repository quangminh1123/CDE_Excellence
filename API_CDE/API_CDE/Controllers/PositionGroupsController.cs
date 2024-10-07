using API_CDE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionGroupsController : ControllerBase
    {
        private readonly IPositionGroup group;
        public PositionGroupsController(IPositionGroup group)
        {
            this.group = group;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(group.PositionGroupList());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(group.GetPositionGroupById(id));
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            var poGr = group.AddPositionGroup(name);
            if (poGr == null)
                return BadRequest();
            return CreatedAtAction("Add", poGr);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, string name)
        {
            var poGr = group.UpdatePositionGroup(id, name);
            if (poGr == null)
                return BadRequest();
            return Ok(poGr);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            string poGr = group.DeletePositionGroup(id);
            if (poGr == "Delete Success")
                return NoContent();
            return BadRequest(poGr);
        }
    }
}
