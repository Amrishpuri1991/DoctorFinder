using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DoctorFinder.EDM
{
    public partial class TblAdmin
    {
        public int AdminId { get; set; }

        [Required(ErrorMessage ="Please enter First name")]
        public string AdminFname { get; set; }

        [Required(ErrorMessage = "Please enter Last name")]
        public string AdminLname { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        public string AdminEmail { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        public string AdminPassword { get; set; }

        public string AdminRole { get; set; }
    }
}
