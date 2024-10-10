﻿using API_CDE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobImagesController : ControllerBase
    {
        private readonly IJobImage jobImage;
        public JobImagesController(IJobImage jobImage)
        {
            this.jobImage = jobImage;
        }

        [HttpGet("{idJob}")]
        public ActionResult Get(int idJob)
        {
            return Ok(jobImage.GetImageByIdJob(idJob));
        }

        [HttpPost]
        public ActionResult Add(IFormFile image, string describe, int idJob)
        {
            var joIm = jobImage.Add(image, describe, idJob);
            if (joIm == null)
                return BadRequest();
            return CreatedAtAction("Add", joIm);
        }
    }
}
