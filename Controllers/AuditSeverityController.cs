using System;
using AuditSeverityModule.Models;
using AuditSeverityModule.Providers;
using Microsoft.AspNetCore.Mvc;

namespace AuditSeverityModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditSeverityController : ControllerBase
    {
        private readonly ISeverityProvider _severityProvider;
        AuditSeverityContext db = new AuditSeverityContext();
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuditSeverityController));
        public AuditSeverityController(ISeverityProvider severityProvider)
        {
            _severityProvider = severityProvider;
        }

        [HttpGet]
        public IActionResult ProjectExecutionStatus()
        {
            _log4net.Info(" Http GET Request From: " + nameof(AuditSeverityController));
            return Ok("SUCCESS");
        }

        [HttpPost]
        public IActionResult ProjectExecutionStatus([FromBody] AuditRequest request)
        {
            _log4net.Info(" Http POST Request From: " + nameof(AuditSeverityController));

            if (request == null)
                return BadRequest();

            if (request.Auditdetails.Type != "Internal")
                return BadRequest("Wrong Audit Type");

            try
            {
                db.AuditRequests.Add(request);
                AuditResponse response = _severityProvider.SeverityResponseProvider(request);
                db.AuditResponses.Add(response);
                db.SaveChanges();
                return Ok(response);
            }
            catch (Exception e)
            {
                _log4net.Error(e.Message);  
                return StatusCode(500);
            }

        }
    }
}
//For Postman test - Put this on body
//{
//    "ProjectName": "Audit Management",
//    "ProjectManagerName": "ADM",
//    "ApplicationOwnerName": "CDE",
//    "Auditdetails": 
//    {
//        "Type": "Internal",
//        "Date": "12/11/2005",
//        "questions": 
//        {
//            "Question1": true,
//            "Question2": true,
//            "Question3": false,
//            "Question4": false,
//            "Question5": false
//        }
//    }
//}