using API_CDE.Services;
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

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(position.PositionList());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(position.GetPosition(id));
        }

        [HttpPost]
        public ActionResult Add(string name, int idPostionGroup)
        {
            var po = position.AddPostion(name, idPostionGroup);
            if (po == null)
                return BadRequest();
            return CreatedAtAction("Add", po);
        }

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
