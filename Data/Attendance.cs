using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApi.Data
{
    public class Attendance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int CandidateId { get; set; }
        public Candidate  Candidate { get; set; }

        public  DateTime DateTime { get; set; }
    }
}
