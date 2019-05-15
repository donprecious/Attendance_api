using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApi.Data
{
    public class OrganisationGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrganisationId { get; set; }

        [ForeignKey("OrganisationId")]
        public Organisation Organisation { get; set; }

        public string PersonGroupId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
