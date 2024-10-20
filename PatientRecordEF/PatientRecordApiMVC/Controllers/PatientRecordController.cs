using PatientRecordEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;

namespace PatientRecordApiMVC.Controllers
{
    [RoutePrefix("api/patientrecord")]
    public class PatientRecordController : ApiController
    {
        private readonly PatientRecordService patientRecordService = new PatientRecordService();

        // GET: /api/patientrecord
        [HttpGet]
        [Route("")]
        public IEnumerable<Patientrecord> GetPatientrecords()
        {
            var patientRecord = patientRecordService.GetAllPatientRecord();
            return patientRecord;
        }

        // GET: /api/patientrecord/id
        [HttpGet]
        [Route("{ID}")]
        public IHttpActionResult GetPatientRecordByID(string ID)
        {
            var record = patientRecordService.GetPatientRecordByID(ID);

            if (record == null)
            {
                return Content(HttpStatusCode.NotFound, new { message = "Record not found", PatientID = ID });
            }

            return Ok(record);
        }

        // GET: /api/patientrecord/name?name=Rohit Verma
        [HttpGet]
        [Route("name")]
        public IHttpActionResult GetPatientRecordByName(string name)
        {
            var record = patientRecordService.GetPatientRecordByName(name);
            if (record == null)
            {
                return Content(HttpStatusCode.NotFound, new { message = "Record not found", PatientName = name });
            }
            return Ok(record);
        }

        // GET: /api/patientrecord/bloodgroup?bloodgroup=O%2B
        [HttpGet]
        [Route("bloodgroup")]
        public IHttpActionResult GetPatientRecordByBloodGroup(string bloodgroup)
        {
            var record = patientRecordService.GetPatientRecordByBloodGroup(bloodgroup);
            if (record == null)
            {
                return Content(HttpStatusCode.NotFound, new { message = "Record not found", BloodGroup = bloodgroup });
            }
            return Ok(record);
        }

        //GET: /api/patientrecord/admitdate?date=2021-06-01
        [HttpGet]
        [Route("admitdate")]
        public IHttpActionResult GetPatientAdmitDate(DateTime date)
        {
            var record = patientRecordService.GetPatientAdmitDate(date);
            if (record == null)
            {
                return Content(HttpStatusCode.NotFound, new { message = "Record not found", AdmitDate = date });
            }
            return Ok(record);
        }

        //GET: /api/patientrecord/medicalcondition?condition=Diabetes
        [HttpGet]
        [Route("medicalcondition")]
        public IHttpActionResult GetPatientByMedicalCondition(string condition)
        {
            var record = patientRecordService.GetPatientByMedicalCondition(condition);
            if (record == null)
            {
                return Content(HttpStatusCode.NotFound, new { message = "Record not found", MedicalCondition = condition });
            }
            return Ok(record);
        }

        // POST: /api/patientrecord
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddPatientRecord(Patientrecord patientrecord)
        {
            if (patientrecord == null)
            {
                return BadRequest("Record is null");
            }
            patientRecordService.AddPatientRecord(patientrecord);
            return Content(HttpStatusCode.Created, new { message = "Record added successfully", Patientrecord = patientrecord });
        }

        // PUT: /api/patientrecord/{id}
        [HttpPut]
        [Route("{ID}")]
        public IHttpActionResult UpdatePatientRecord(Patientrecord patientrecord)
        {
            if (patientrecord == null)
            {
                return BadRequest("Record is null");
            }
            var existingRecord = patientRecordService.GetPatientRecordByID(patientrecord.id);
            if (existingRecord == null)
            {
                return Content(HttpStatusCode.NotFound, new { message = "Record not found", PatientID = patientrecord.id });
            }
            patientRecordService.UpdatePatientRecord(patientrecord);

            return Content(HttpStatusCode.OK, new { message = "Record updated successfully", Patientrecord = patientrecord });

            //if (patientrecord == null)
            //{
            //    return BadRequest("Record is null");
            //}
            //patientRecordService.UpdatePatientRecord(patientrecord);
            //return Content(HttpStatusCode.OK, new { message = "Record updated successfully", Patientrecord = patientrecord });
        }

        // DELETE: /api/patientrecord/{id}
        [HttpDelete]
        [Route("{ID}")]
        public IHttpActionResult DeletePatientRecord(string ID)
        {
            var record = patientRecordService.GetPatientRecordByID(ID);
            if (record == null)
            {
                return Content(HttpStatusCode.NotFound, new { message = "Record not found", PatientID = ID });
            }
            patientRecordService.DeletePatientRecord(ID);
            return Content(HttpStatusCode.OK, new { message = "Record deleted successfully", PatientID = ID });
        }
    }
}
