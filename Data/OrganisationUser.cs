using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AttendanceApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AttendanceApi.Data
{
    public class OrganisationUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }
         
        public string  UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int OrganisationId { get; set; }
        [ForeignKey("OrganisationId")]
        public Organisation Organisation { get; set; }

    }
}
