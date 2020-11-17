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

        [HttpPost("{id}/uploadImage")]
        public HttpResponseMessage handleImage(FileUPloadAPI image)
        {

            try
            {
                if (image.files.Length > 0)
                {
                    string photosDatabase = AppDomain.CurrentDomain.BaseDirectory + "/Database/photos/";

                    if (!Directory.Exists(photosDatabase))
                    {
                        Directory.CreateDirectory(photosDatabase);
                    }

                    using (FileStream fileStream = System.IO.File.Create(photosDatabase + "/" + image.files.FileName))
                    {
                        image.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                    }
                }

                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {

                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

    }
}
