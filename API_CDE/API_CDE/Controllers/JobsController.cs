﻿using API_CDE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJob job;
        public JobsController(IJob job)
        {
            this.job = job;
        }

        //[Authorize(Roles = "Owner,Admin,User")]
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(job.GetJob(id));
        }

        //[Authorize(Roles = "Owner,Admin,User")]
        [HttpGet("ByCreator/{idCreator}")]
        public ActionResult GetByIdCreator(int idCreator) { 
            return Ok(job.GetJobByIdCreator(idCreator));
        }

        //[Authorize(Roles = "Owner,Admin,User")]
        [HttpGet("ByImplementer/{idImplementer}")]
        public ActionResult GetByIdImplementer(int idImplementer)
        {
            return Ok(job.GetJobByIdImplementer(idImplementer));
        }

        //[Authorize(Roles = "Owner,Admin,User")]
        [HttpPost]
        public ActionResult Add(string title, string Descibe, DateTime startDate, DateTime endDate, int idViSc, int idImplementer, int idCreator)
        {
            var j = job.Add(title, Descibe, startDate, endDate, idViSc, idImplementer, idCreator);
            if (j == null)
                return BadRequest();
            return CreatedAtAction("Add",j);
        }

        /*[Authorize(Roles = "Owner,Admin,User")]*/
        [HttpPut("{id}")]
        public ActionResult Update(int id, string status)
        {
            var j = job.UpdateStatus(id, status);
            if (j == null)
                return BadRequest();
            return Ok(j);
        }
    }
}
