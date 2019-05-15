using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApi.Data
{
    public class CandidatePhoto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public  int CandidateId { get; set; }

        [ForeignKey("CandidateId")]
        public  Candidate Candidate { get; set; }

    }
}
