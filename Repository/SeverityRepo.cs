using AuditSeverityModule.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditSeverityModule.Repository
{
    public class SeverityRepo : ISeverityRepo
    {
        AuditSeverityContext db = new AuditSeverityContext();

        public AuditResponse SeverityResponse(AuditRequest Request)
        {
                int count = 0;

                foreach (var x in Request.Auditdetails.questions)
                {
                    if (x.Question == true)
                    {
                        count++;
                    }
                }
                //if (Req.Auditdetails.questions.Question1 == true)
                //    count++;
                //if (Req.Auditdetails.questions.Question2 == true)
                //    count++;
                //if (Req.Auditdetails.questions.Question3 == true)
                //    count++;
                //if (Req.Auditdetails.questions.Question4 == true)
                //    count++;
                //if (Req.Auditdetails.questions.Question5 == true)
                //    count++;

                //Random randomNumber = new Random();

                AuditResponse auditResponse = new AuditResponse();
                AuditBenchmark auditBenchmark = db.AuditBenchmarks.Where(x=>x.auditType==Request.Auditdetails.Type).FirstOrDefault();
                if ( count >= auditBenchmark.benchmarkNoAnswers)
                {
                    //auditResponse.AuditId = randomNumber.Next();
                    auditResponse.ProjectExecutionStatus = "GREEN";
                    auditResponse.RemedialActionDuration = "No action needed";
                }
                else 
                {
                    //auditResponse.AuditId = randomNumber.Next();
                    auditResponse.ProjectExecutionStatus = "RED";
                    auditResponse.RemedialActionDuration = "Action to be taken in 2 weeks";
                }
                
                return auditResponse;
            
        }
    }
}
