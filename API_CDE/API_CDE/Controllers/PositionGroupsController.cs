using API_CDE.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Owner,Admin")]
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(group.PositionGroupList());
        }

        [Authorize(Roles = "Owner,Admin")]
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(group.GetPositionGroupById(id));
        }

        [Authorize(Roles = "Owner,Admin")]
        [HttpPost]
        public ActionResult Add(string name)
        {
            var poGr = group.AddPositionGroup(name);
            if (poGr == null)
                return BadRequest();
            return CreatedAtAction("Add", poGr);
        }

        [Authorize(Roles = "Owner,Admin")]
        [HttpPut("{id}")]
        public ActionResult Update(int id, string name)
        {
            var poGr = group.UpdatePositionGroup(id, name);
            if (poGr == null)
                return BadRequest();
            return Ok(poGr);
        }

        [Authorize(Roles = "Owner,Admin")]
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
