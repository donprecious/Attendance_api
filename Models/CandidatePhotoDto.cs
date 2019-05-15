using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApi.Models
{
    public class CandidatePhotoDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public  int CandidateId { get; set; }

        [ForeignKey("CandidateId")]
        public  CandidateDto Candidate { get; set; }

    }
}
