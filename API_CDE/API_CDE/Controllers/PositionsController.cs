using API_CDE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPosition position;
        public PositionsController(IPosition position)
        {
            this.position = position;
        }

        [Authorize(Roles = "Owner,Admin")]
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(position.PositionList());
        }

        [Authorize(Roles = "Owner,Admin")]
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(position.GetPosition(id));
        }

        [Authorize(Roles = "Owner,Admin")]
        [HttpPost]
        public ActionResult Add(string name, int idPostionGroup)
        {
            var po = position.AddPostion(name, idPostionGroup);
            if (po == null)
                return BadRequest();
            return CreatedAtAction("Add", po);
        }

        [Authorize(Roles = "Owner,Admin")]
        [HttpPut("{id}")]
        public ActionResult Update(int id, string name)
        {
            var pos = position.UpdatePosition(id, name);
            if (pos == null)
                return BadRequest();
            return Ok(pos);
        }
    }
}
