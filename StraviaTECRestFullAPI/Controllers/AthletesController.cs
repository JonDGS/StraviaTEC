using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StraviaTECRestFullAPI.DataAccess;
using StraviaTECRestFullAPI.Models;
using StraviaTECRestFullAPI.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Controllers
{
    [Route("api/[controller]")]
    public class AthletesController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public AthletesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Athlete> Get()
        {
            return _dataAccessProvider.GetAthleteRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                athlete.id = obj.ToString();
                _dataAccessProvider.AddAthleteRecord(athlete);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Athlete Details(string id)
        {
            return _dataAccessProvider.GetAthleteSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateAthleteRecord(athlete);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(string id)
        {
            var data = _dataAccessProvider.GetAthleteSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteAthleteRecord(id);
            return Ok();
        }

        [HttpPost("uploadImage")]
        public IActionResult handleImage(FileUPloadAPI image)
        {

            string token = Request.Form["token"].ToString();

            try
            {
                if (image.files.Length > 0)
                {
                    string savedLocation = FileManager.saveFile(image, token);

                    if (savedLocation == null)
                    {
                        return Forbid("File extension is not valid");
                    }
                    
                    return Ok("Saved successfully");

                }

                return NotFound("No data to process");
            }
            catch (Exception ex)
            {

                return BadRequest("");
            }
        }

        [HttpGet("getProfilePicture")]
        public IActionResult getProfilePicture()
        {
            string token = Request.Form["token"].ToString();

            try
            {
                return new FileStreamResult(FileManager.getUserPhoto(token), "application/octet-stream");
            }
            catch (Exception)
            {

                return NotFound("Image was not found");
            }
        }

    }
}
