using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AuditSeverityModule.Models
{
    public class AuditDetail
    {
        [Key]
        public int AuditDetailId { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public List<Questions> questions { get; set; }
    }
}
