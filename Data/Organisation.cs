﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AttendanceApi.Models;

namespace AttendanceApi.Data
{
    public class Organisation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public string Email { get; set; }

        [ForeignKey("User")]
        public string CreatedBy { get; set; }
        public ApplicationUser User { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
