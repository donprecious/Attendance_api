using System; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApi.Models
{
    public class CandidateDto
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PersonId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string PrimaryPhotoUrl { get; set; }
        public string UniqueId { get; set; }

        public int OrganisationGroupId { get; set; }
        //[ForeignKey("OrganisationGroupId")]
        //public OrganisationGroupDto OrganisationGroup { get; set; }

        //public ICollection<CandidatePhoto> CandidatePhotos { get; set; }
    }
}
