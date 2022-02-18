using System;
using System.Collections.Generic;

#nullable disable

namespace DoctorFinder.EDM
{
    public partial class TblDoctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorAddressLine1 { get; set; }
        public string DoctorAddressLine2 { get; set; }
        public string DoctorAddressLine3 { get; set; }
        public string DoctorEmail { get; set; }
        public int? DoctorOfficeNumber { get; set; }
        public int? DoctorMobileNumber { get; set; }
        public string DoctorQualification { get; set; }
        public string DoctorSpeciality { get; set; }
        public string DoctorProfileImage { get; set; }
        public int? HospitalId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }

        public virtual TblCity City { get; set; }
        public virtual TblHospital Hospital { get; set; }
        public virtual TblState State { get; set; }
    }
}
