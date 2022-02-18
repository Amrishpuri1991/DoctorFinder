using System;
using System.Collections.Generic;

#nullable disable

namespace DoctorFinder.EDM
{
    public partial class TblHospital
    {
        public TblHospital()
        {
            TblAppointments = new HashSet<TblAppointment>();
            TblDoctors = new HashSet<TblDoctor>();
        }

        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string HospitalAddressLine1 { get; set; }
        public string HospitalAddressLine2 { get; set; }
        public string HospitalAddressLine3 { get; set; }
        public string HospitalSuburb { get; set; }
        public string HospitalEmail { get; set; }
        public int? HospitalPhone { get; set; }
        public string HospitalProfileImage { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }

        public virtual TblCity City { get; set; }
        public virtual TblState State { get; set; }
        public virtual ICollection<TblAppointment> TblAppointments { get; set; }
        public virtual ICollection<TblDoctor> TblDoctors { get; set; }
    }
}
