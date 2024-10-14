using API_CDE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorsController : ControllerBase
    {
        private readonly IDistributor distributor;
        public DistributorsController(IDistributor distributor)
        {
            this.distributor = distributor;
        }

        [Authorize(Roles = "Owner,Admin")]
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(distributor.DistributorList());
        }

        [Authorize(Roles = "Owner,Admin")]
        [HttpGet("{id}")]
        public ActionResult GetId(int id)
        {
            return Ok(distributor.GetDistributor(id));
        }

        [Authorize(Roles = "Owner")]
        [HttpPost]
        public ActionResult Add(string name, string address, string phone, int? idArea, int? idManager, string status)
        {
            var dis = distributor.AddDistributor(name, address, phone, idArea, idManager, status);
            if (dis == null)
                return BadRequest();
            return CreatedAtAction("Add", dis);
        }

        [Authorize(Roles = "Owner,Admin")]
        [HttpPut]
        public ActionResult Update(int id, string name, string address, string phone, int? idArea, int? idManager, string status)
        {
            var dis = distributor.UpdateDistributor(id, name, address, phone, idArea, idManager, status);
            if (dis == null)
                return BadRequest();
            return Ok(dis);
        }

        [Authorize(Roles = "Owner")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            string dis = distributor.DeleteDistributor(id);
            if (dis == "Delete Success")
                return NoContent();
            return BadRequest(dis);
        }
    }
}
