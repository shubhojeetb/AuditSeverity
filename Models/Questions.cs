using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AuditSeverityModule.Models
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }
        public int QuestionNo { get; set; }
        public bool Question { get; set; }
    }

}
