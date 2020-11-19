using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StraviaTECRestFullAPI.DataAccess;
using StraviaTECRestFullAPI.Models;
using StraviaTECRestFullAPI.Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaTECRestFullAPI.Controllers
{
    [Route("api/[controller]")]
    public class organizersController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public organizersController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Organizer> Get()
        {
            return _dataAccessProvider.GetOrganizerRecords();
        }

        [HttpGet]
        [Route("GetNames")]
        public Array GetNames()
        {
           return _dataAccessProvider.GetOrganizersName();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                organizer.id = obj.ToString();
                _dataAccessProvider.AddOrganizerRecord(organizer);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{token}")]
        public Organizer Details(string token)
        {
            return _dataAccessProvider.GetOrganizerSingleRecord(token);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateOrganizerRecord(organizer);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(string id)
        {
            var data = _dataAccessProvider.GetOrganizerSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteOrganizerRecord(id);
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

                    if (savedLocation.Equals(null))
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
    }
}
