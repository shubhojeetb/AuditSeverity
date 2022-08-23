using AuditSeverityModule.Models;
using AuditSeverityModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuditSeverityModule.Providers
{
    public class SeverityProvider : ISeverityProvider
    {
        private readonly ISeverityRepo _severityRepo;
       // private  AuditBenchmark _auditBenchmark;
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(SeverityProvider));
        public SeverityProvider(ISeverityRepo severityRepo)
        {
            _severityRepo = severityRepo;
        }
        public AuditResponse SeverityResponseProvider(AuditRequest Req)
        {
            _log4net.Info(" SeverityResponse Method of SeverityProvider Called ");
            try
            {
                AuditResponse auditResponse = new AuditResponse();
                auditResponse = _severityRepo.SeverityResponse(Req);
                return auditResponse;
            }
            catch (Exception ex)
            {
                _log4net.Error(ex.Message);
                return null;
            }

            //try
            //{
            //    int count = 0;
            //    _auditBenchmark = new AuditBenchmark() { auditType = "Internal", benchmarkNoAnswers = 3 };

            //    foreach (var x in Req.Auditdetails.questions)
            //    {
            //        if (x.Question == true)
            //        {
            //            count++;
            //        }
            //    }
            //    //if (Req.Auditdetails.questions.Question1 == true)
            //    //    count++;
            //    //if (Req.Auditdetails.questions.Question2 == true)
            //    //    count++;
            //    //if (Req.Auditdetails.questions.Question3 == true)
            //    //    count++;
            //    //if (Req.Auditdetails.questions.Question4 == true)
            //    //    count++;
            //    //if (Req.Auditdetails.questions.Question5 == true)
            //    //    count++;

            //    //Random randomNumber = new Random();

            //    AuditResponse auditResponse = new AuditResponse();
            //    if (Req.Auditdetails.Type == _auditBenchmark.auditType && count >= _auditBenchmark.benchmarkNoAnswers)
            //    {
            //        //auditResponse.AuditId = randomNumber.Next();
            //        auditResponse.ProjectExecutionStatus = SeverityRepo.ActionToTakeAndStatus[0].ProjectExecutionStatus;
            //        auditResponse.RemedialActionDuration = SeverityRepo.ActionToTakeAndStatus[0].RemedialActionDuration;
            //    }
            //    else
            //    {
            //        auditResponse.AuditId = randomNumber.Next();
            //        auditResponse.ProjectExecutionStatus = SeverityRepo.ActionToTakeAndStatus[1].ProjectExecutionStatus;
            //        auditResponse.RemedialActionDuration = SeverityRepo.ActionToTakeAndStatus[1].RemedialActionDuration;
            //    }

            //    return auditResponse;
            //}
            //catch(Exception ex)
            //{
            //    _log4net.Error(ex.Message);
            //    return null;
            //}


        }
    }
}
